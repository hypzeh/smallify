using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Smallify.Enums;
using Smallify.Interfaces;
using Smallify.Models;
using Smallify.Utility;
using Smallify.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Smallify.ViewModels
{
	public class ShellViewModel : BindableBase
	{
		private readonly ILayoutManger _layoutManager;

		private string _title;
		private double _shellWidth;
		private double _shellHeight;
		private double _shellTop;
		private double _shellLeft;

		private UpdateWindow _updateWindow;

		private List<IPlayer> _playerList;
		private IPlayer _player;

		public ShellViewModel()
		{
			this.Title = "Smallify";

			this.Smallify = new SmallifyViewModel();
			this.Smallify.PropertyChanged += this.Smallify_PropertyChanged;

			// Define all Players
			this._playerList = new List<IPlayer>
			{
				new PlayerModel(PlayerType.Bar, 600, 100, 300, 50),
				new PlayerModel(PlayerType.Album, 600, 600, 100, 100),
				new PlayerModel(PlayerType.MediaControl, 200, 100, 200, 50)
			};

			// Load settings
			this._layoutManager = new LayoutManager();
			this.LoadShellLayout();

			// Application command
			this.UpdateWindowCommand = new DelegateCommand(this.UpdateWindowCommand_Execute);
			this.ExitApplicationCommand = new DelegateCommand(() => App.Current.Shutdown());
			this.AlwaysOnTopCommand = new DelegateCommand(() => this.IsAlwaysOnTop = !App.Current.MainWindow.Topmost);

			// Player switch commands
			this.BarPlayerCommand = new DelegateCommand(() => this.SwitchPlayerTo(PlayerType.Bar), () => this.Player.PlayerType != PlayerType.Bar);
			this.AlbumPlayerCommand = new DelegateCommand(() => this.SwitchPlayerTo(PlayerType.Album), () => this.Player.PlayerType != PlayerType.Album);
			this.MediaControlPlayerCommand = new DelegateCommand(() => this.SwitchPlayerTo(PlayerType.MediaControl), () => this.Player.PlayerType != PlayerType.MediaControl);

			this.UpdateWindowCommand.Execute(null);
		}

		public ICommand UpdateWindowCommand { get; private set; }

		public ICommand ExitApplicationCommand { get; private set; }

		public ICommand AlwaysOnTopCommand { get; private set; }

		public ICommand BarPlayerCommand { get; private set; }

		public ICommand AlbumPlayerCommand { get; private set; }

		public ICommand MediaControlPlayerCommand { get; private set; }

		public SmallifyViewModel Smallify { get; }

		public string Title
		{
			get
			{
				return this._title;
			}

			set
			{
				this.SetProperty<string>(ref this._title, value);
				this.OnPropertyChanged(nameof(this.Title));
			}
		}

		public double ShellWidth
		{
			get
			{
				return this._shellWidth;
			}

			set
			{
				if (this.SetProperty<double>(ref this._shellWidth, value))
				{
					this.SaveShellLayoutValues();
					this.OnPropertyChanged(nameof(this.ShellWidth));
				}
			}
		}

		public double ShellHeight
		{
			get
			{
				return this._shellHeight;
			}

			set
			{
				if (this.SetProperty<double>(ref this._shellHeight, value))
				{
					this.SaveShellLayoutValues();
					this.OnPropertyChanged(nameof(this.ShellHeight));
				}
			}
		}

		public double ShellTop
		{
			get
			{
				return this._shellTop;
			}

			set
			{
				if (this.SetProperty<double>(ref this._shellTop, value))
				{
					this.SaveShellLayoutValues();
					this.OnPropertyChanged(nameof(this.ShellTop));
				}
			}
		}

		public double ShellLeft
		{
			get
			{
				return this._shellLeft;
			}

			set
			{
				if (this.SetProperty<double>(ref this._shellLeft, value))
				{
					this.SaveShellLayoutValues();
					this.OnPropertyChanged(nameof(this.ShellLeft));
				}
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
				this.SavePreferenceVales();
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
				this.SavePlayerValues();
				this.OnPropertyChanged(nameof(this.Player));
			}
		}

		public double TrackProgression
		{
			get
			{
				if (this.Player.PlayerType == PlayerType.Bar)
				{
					return (this.Smallify.TrackProgression * (this.ShellWidth - this.ShellHeight)) / this.Smallify.Length;
				}

				return (this.Smallify.TrackProgression * this.ShellWidth) / this.Smallify.Length;
			}
		}

		private void UpdateWindowCommand_Execute()
		{
			if (this._updateWindow == null)
			{
				this._updateWindow = new UpdateWindow();
				if (this._updateWindow != null)
				{
					this._updateWindow.Closed += this.UpdateWindow_Closed;
				}
			}
		}

		private void UpdateWindow_Closed(object sender, System.EventArgs e)
		{
			this._updateWindow.Closed -= this.UpdateWindow_Closed;
			this._updateWindow = null;
		}

		private void SwitchPlayerTo(PlayerType playerType)
		{
			// Save current Shell size to current player and save it against the player list
			this.Player.Width = this.ShellWidth;
			this.Player.Height = this.ShellHeight;

			// Change Player
			this.Player = this._playerList.FirstOrDefault(x => x.PlayerType == playerType);
			((DelegateCommand)this.BarPlayerCommand).RaiseCanExecuteChanged();
			((DelegateCommand)this.AlbumPlayerCommand).RaiseCanExecuteChanged();
			((DelegateCommand)this.MediaControlPlayerCommand).RaiseCanExecuteChanged();

			// Set Shell size to player
			this.ShellWidth = this.Player.Width;
			this.ShellHeight = this.Player.Height;
		}

		private void LoadShellLayout()
		{
			var settings = this._layoutManager.LoadLayout();
			this.ShellWidth = settings.Width;
			this.ShellHeight = settings.Height;
			this.ShellTop = settings.Top;
			this.ShellLeft = settings.Left;
			this.Player = this._playerList.FirstOrDefault<IPlayer>(x => x.PlayerType == settings.PlayerType);
			this.IsAlwaysOnTop = settings.IsTopMost;
		}

		private void SaveShellLayoutValues()
		{
			this._layoutManager.SaveLayout(this.ShellWidth, this.ShellHeight, this.ShellTop, this.ShellLeft);
		}

		private void SavePlayerValues()
		{
			this._layoutManager.SavePlayer(this.Player.PlayerType);
		}

		private void SavePreferenceVales()
		{
			this._layoutManager.SavePreferences(this.IsAlwaysOnTop);
		}

		private void Smallify_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "TrackProgression")
			{
				this.OnPropertyChanged(nameof(this.TrackProgression));
			}

			if (this.Smallify.IsPlaying 
				&& !this.Smallify.IsAdvert
				&& e.PropertyName == "IsPlaying"
				|| e.PropertyName == "Name"
				|| e.PropertyName == "Artist")
			{
				this.Title = string.Format("{0} - {1}", this.Smallify.Artist, this.Smallify.Name);
			}
			else if (!this.Smallify.IsPlaying || this.Smallify.IsAdvert)
			{
				this.Title = "Smallify";
			}
		}
	}
}