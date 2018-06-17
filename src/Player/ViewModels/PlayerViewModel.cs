using Player.Models;
using Prism.Commands;
using Prism.Mvvm;
using SpotifyAPI.Local.Enums;
using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace Player.ViewModels
{
	public class PlayerViewModel : BindableBase
	{
		private readonly PlayerModel _player;
		private readonly DispatcherTimer _trackTimer;

		private string _albumArtURL;
		private string _albumName;
		private string _artistName;
		private bool _isConnected;
		private bool _isPlaying;
		private TimeSpan _trackLength;
		private string _trackName;
		private TimeSpan _trackTime;

		public PlayerViewModel(PlayerModel player)
		{
			this._player = player;
			this._trackTimer = new DispatcherTimer(DispatcherPriority.DataBind)
			{
				Interval = TimeSpan.FromSeconds(1d)
			};

			this._player.ConnectToSpotify();

			this._isConnected = this._player.IsConnected;
			this._isPlaying = this._player.IsPlaying;
			this._trackName = this._player?.CurrentTrack?.TrackResource?.Name ?? string.Empty;
			this._artistName = this._player?.CurrentTrack?.ArtistResource?.Name ?? string.Empty;
			this._albumName = this._player?.CurrentTrack?.AlbumResource?.Name ?? string.Empty;
			this._albumArtURL = this._player?.GetClientStatus()?.Track?.GetAlbumArtUrl(AlbumArtSize.Size640) ?? string.Empty;
			this._trackLength = TimeSpan.FromSeconds(this._player?.CurrentTrack?.Length ?? 0);
			this._trackTime = TimeSpan.FromSeconds(this._player.TrackTime);

			this._player.PropertyChanged += this.Player_PropertyChanged;
			this._trackTimer.Tick += this.ProgressTimer_Tick;

			this._trackTimer.Start();

			this.PlayCommand = new DelegateCommand(
				async () => await this._player.Play(),
				() => this._player.GetClientStatus()?.PlayEnabled ?? false);

			this.PauseCommand = new DelegateCommand(
				async () => await this._player.Pause(),
				() => this._player.GetClientStatus()?.PlayEnabled ?? false);

			this.SkipCommand = new DelegateCommand(
				() => this._player.Skip(),
				() => this._player.GetClientStatus()?.NextEnabled ?? false);

			this.PreviousCommand = new DelegateCommand(
				() => this._player.Previous(),
				() => this._player.GetClientStatus()?.PrevEnabled ?? false);
		}

		public string AlbumArtURL
		{
			get
			{
				return this._albumArtURL;
			}

			set
			{
				this.SetProperty(ref this._albumArtURL, value);
			}
		}

		public string AlbumName
		{
			get
			{
				return this._albumName;
			}

			set
			{
				this.SetProperty(ref this._albumName, value);
			}
		}

		public string ArtistName
		{
			get
			{
				return this._artistName;
			}

			set
			{
				this.SetProperty(ref this._artistName, value);
			}
		}

		public bool IsConnected
		{
			get
			{
				return this._isConnected;
			}

			set
			{
				this.SetProperty(ref this._isConnected, value);
			}
		}

		public bool IsPlaying
		{
			get
			{
				return this._isPlaying;
			}

			set
			{
				this.SetProperty(ref this._isPlaying, value);
			}
		}

		public ICommand PauseCommand { get; private set; }

		public ICommand PlayCommand { get; private set; }

		public ICommand PreviousCommand { get; private set; }

		public ICommand SkipCommand { get; private set; }

		public TimeSpan TrackLength
		{
			get
			{
				return this._trackLength;
			}

			set
			{
				this.SetProperty(ref this._trackLength, value);
			}
		}

		public string TrackName
		{
			get
			{
				return this._trackName;
			}

			set
			{
				this.SetProperty(ref this._trackName, value);
			}
		}

		public TimeSpan TrackTime
		{
			get
			{
				return this._trackTime;
			}

			set
			{
				this.SetProperty(ref this._trackTime, value);
			}
		}

		private void Player_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			((DelegateCommand)this.PlayCommand).RaiseCanExecuteChanged();
			((DelegateCommand)this.PauseCommand).RaiseCanExecuteChanged();
			((DelegateCommand)this.SkipCommand).RaiseCanExecuteChanged();
			((DelegateCommand)this.PreviousCommand).RaiseCanExecuteChanged();

			switch (e.PropertyName)
			{
				case nameof(this._player.IsConnected):
					this.IsConnected = this._player.IsConnected;
					break;

				case nameof(this._player.IsPlaying):
					this.IsPlaying = this._player.IsPlaying;
					break;

				case nameof(this._player.CurrentTrack):
					var status = this._player.GetClientStatus();

					this.TrackName = status?.Track?.TrackResource?.Name ?? string.Empty;
					this.ArtistName = status?.Track?.ArtistResource?.Name ?? string.Empty;
					this.AlbumName = status?.Track?.AlbumResource?.Name ?? string.Empty;
					this.AlbumArtURL = status?.Track?.GetAlbumArtUrl(AlbumArtSize.Size640) ?? string.Empty;
					this.TrackLength = TimeSpan.FromSeconds(status?.Track?.Length ?? 0);
					this.TrackTime = TimeSpan.FromSeconds(this._player.TrackTime);
					break;
			}
		}

		private void ProgressTimer_Tick(object sender, EventArgs e)
		{
			this.TrackTime = TimeSpan.FromSeconds(this._player.TrackTime);
		}
	}
}