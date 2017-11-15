using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Smallify.Enums;
using Smallify.Interfaces;
using Smallify.Models;
using Squirrel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smallify.ViewModels
{
	public class SmallifyViewModel : BindableBase
	{
		private readonly DelegateCommand _exitApplicationCommand;
		private readonly DelegateCommand _alwaysOnTopCommand;
		private readonly DelegateCommand _barPlayerCommand;
		private readonly DelegateCommand _albumPlayerCommand;
		private readonly DelegateCommand _playPauseCommand;
		private readonly DelegateCommand _skipCommand;
		private readonly DelegateCommand _previousCommand;

		private int _width;
		private int _height;
		private List<IPlayer> _playerList;
		private IPlayer _player;
		private ITrack _track;

		public SmallifyViewModel()
		{
			// Define all Players
			this._playerList = new List<IPlayer>
			{
				new PlayerModel(PlayerType.Bar, 600, 100, 200, 50),
				new PlayerModel(PlayerType.Album, 600, 600, 100, 100)
			};

			// Set active player out of the player list & set the Shell size to the player
			this._player = this._playerList.FirstOrDefault<IPlayer>(x => x.PlayerType == PlayerType.Bar);
			this._width = this._player.Width;
			this._height = this._player.Height;

			this._track = new TrackModel();
			this._track.PropertyChanged += this.Track_PropertyChanged;

			App.Current.MainWindow.Topmost = true;

			// Application command
			this._exitApplicationCommand = new DelegateCommand(() => App.Current.Shutdown());
			this._alwaysOnTopCommand = new DelegateCommand(() => this.IsAlwaysOnTop = !App.Current.MainWindow.Topmost);

			// Player switch commands
			this._barPlayerCommand = new DelegateCommand(() => this.SwitchPlayerTo(PlayerType.Bar), () => this.Player.PlayerType != PlayerType.Bar);
			this._albumPlayerCommand = new DelegateCommand(() => this.SwitchPlayerTo(PlayerType.Album), () => this.Player.PlayerType != PlayerType.Album);

			// Media commands
			this._playPauseCommand = new DelegateCommand(this.Track.PlayPause);
			this._skipCommand = new DelegateCommand(this.Track.Skip);
			this._previousCommand = new DelegateCommand(this.Track.Previous);
		}

		public ICommand ExitApplicationCommand
		{
			get
			{
				return this._exitApplicationCommand;
			}
		}

		public ICommand AlwaysOnTopCommand
		{
			get
			{
				return this._alwaysOnTopCommand;
			}
		}

		public ICommand BarPlayerCommand
		{
			get
			{
				return this._barPlayerCommand;
			}
		}

		public ICommand AlbumPlayerCommand
		{
			get
			{
				return this._albumPlayerCommand;
			}
		}

		public ICommand PlayPauseCommand
		{
			get
			{
				return this._playPauseCommand;
			}
		}

		public ICommand SkipCommand
		{
			get
			{
				return this._skipCommand;
			}
		}

		public ICommand PreviousCommand
		{
			get
			{
				return this._previousCommand;
			}
		}

		public int Width
		{
			get
			{
				return this._width;
			}

			set
			{
				this.SetProperty<int>(ref this._width, value);
				this.OnPropertyChanged(nameof(this.Width));
			}
		}

		public int Height
		{
			get
			{
				return this._height;
			}

			set
			{
				this.SetProperty<int>(ref this._height, value);
				this.OnPropertyChanged(nameof(this.Height));
			}
		}

		public bool IsAlwaysOnTop
		{
			get
			{
				return App.Current.MainWindow.Topmost;
			}

			set
			{
				App.Current.MainWindow.Topmost = value;
				this.OnPropertyChanged(nameof(this.IsAlwaysOnTop));
			}
		}

		public IPlayer Player
		{
			get
			{
				return this._player;
			}

			set
			{
				this.SetProperty<IPlayer>(ref this._player, value);
				this.OnPropertyChanged(nameof(this.Player));
				this._barPlayerCommand.RaiseCanExecuteChanged();
				this._albumPlayerCommand.RaiseCanExecuteChanged();
			}
		}

		public ITrack Track
		{
			get
			{
				return this._track;
			}
		}

		public double TrackProgressionToWidth
		{
			get
			{
				return (this.Track.TrackProgression * this.Width) / this.Track.Length;
			}
		}

		private void SwitchPlayerTo(PlayerType playerType)
		{
			// Save current Shell size to current player and save it against the player list
			this.Player.Width = this.Width;
			this.Player.Height = this.Height;
			this._playerList[this._playerList.FindIndex(x => x.PlayerType == this.Player.PlayerType)] = this.Player;

			// Change Player
			this.Player = this._playerList.FirstOrDefault(x => x.PlayerType == playerType);

			// Set Shell size to player
			this.Width = this.Player.Width;
			this.Height = this.Player.Height;
		}

		private void Track_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			this.OnPropertyChanged(nameof(this.Track));
			this.OnPropertyChanged(nameof(this.TrackProgressionToWidth));
		}
	}
}