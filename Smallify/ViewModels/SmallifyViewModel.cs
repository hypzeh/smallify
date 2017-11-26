using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using NLog;
using Smallify.Utility;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Smallify.ViewModels
{
	public class SmallifyViewModel : BindableBase
	{
		private static Logger GetLogger = LogManager.GetCurrentClassLogger();

		private readonly SpotifyLocalAPI _spotify;

		private string _name;
		private string _artist;
		private string _album;
		private BitmapSource _albumArt;
		private int _length;
		private double _trackProgression;
		private bool _isPlaying;
		private bool _isAdvert;

		private List<string> dummyStringList;

		public SmallifyViewModel()
		{
			this._spotify = new SpotifyLocalAPI();

			this.dummyStringList = new List<string>
			{
				@"Wherefore art thou Spotify? >:(",
				@"¯\_(ツ)_/¯",
			};

			this.Name = "Smallify";
			this.Artist = this.dummyStringList.PickRandom();

			Task.Run(() =>
			{
				this.LaunchSpotify();
				this.LaunchSpotifyWebHelper();
				this.GetSpotifyTrack();
			});

			this._spotify.OnTrackChange += this.Spotify_OnTrackChange;
			this._spotify.OnTrackTimeChange += this.Spotify_OnTrackTimeChange;
			this._spotify.OnPlayStateChange += this.Spotify_OnPlayStateChange;

			this._spotify.ListenForEvents = true;

			this.PlayPauseCommand = new DelegateCommand(this.PlayPauseCommand_Execute);
			this.SkipCommand = new DelegateCommand(this.SkipCommand_Execute);
			this.PreviousCommand = new DelegateCommand(this.PreviousCommand_Execute);
		}

		public ICommand PlayPauseCommand { get; private set; }

		public ICommand SkipCommand { get; private set; }

		public ICommand PreviousCommand { get; private set; }

		public string Name
		{
			get
			{
				return this._name;
			}

			set
			{
				this.SetProperty<string>(ref this._name, value);
				this.OnPropertyChanged(nameof(this.Name));
			}
		}

		public string Artist
		{
			get
			{
				return this._artist;
			}

			set
			{
				this.SetProperty<string>(ref this._artist, value);
				this.OnPropertyChanged(nameof(this.Artist));
			}
		}

		public string Album
		{
			get
			{
				return this._album;
			}

			set
			{
				this.SetProperty<string>(ref this._album, value);
				this.OnPropertyChanged(nameof(this.Album));
			}
		}

		public BitmapSource AlbumArt
		{
			get
			{
				return this._albumArt;
			}

			set
			{
				this.SetProperty<BitmapSource>(ref this._albumArt, value);
				this.OnPropertyChanged(nameof(this.AlbumArt));
			}
		}

		public int Length
		{
			get
			{
				return this._length;
			}

			set
			{
				this.SetProperty<int>(ref this._length, value);
				this.OnPropertyChanged(nameof(this.Length));
			}
		}

		public double TrackProgression
		{
			get
			{
				return this._trackProgression;
			}

			set
			{
				this.SetProperty<double>(ref this._trackProgression, value);
				this.OnPropertyChanged(nameof(this.TrackProgression));
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
				this.SetProperty<bool>(ref this._isPlaying, value);
				this.OnPropertyChanged(nameof(this.IsPlaying));
			}
		}

		public bool IsAdvert
		{
			get
			{
				return this._isAdvert;
			}

			set
			{
				this.SetProperty<bool>(ref this._isAdvert, value);
				this.OnPropertyChanged(nameof(this.IsAdvert));
			}
		}

		public void PlayPauseCommand_Execute()
		{
			try
			{
				if (this._spotify.GetStatus().PlayEnabled)
				{
					if (this.IsPlaying)
					{
						this._spotify.Pause();
					}
					else
					{
						this._spotify.Play();
					}

					this.IsPlaying = !this.IsPlaying;
				}
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "[SPOTIFY] Failed to execute 'Play/Pause' command: {0}", ex.Message);
				this.UpdateInfoWithSpotifyConnection();
			}
		}

		public void SkipCommand_Execute()
		{
			try
			{
				if (this._spotify.GetStatus().NextEnabled)
				{
					this._spotify.Skip();
				}
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "[SPOTIFY] Failed to execute 'Skip' command: {0}", ex.Message);
				this.UpdateInfoWithSpotifyConnection();
			}
		}

		public void PreviousCommand_Execute()
		{
			try
			{
				if (this._spotify.GetStatus().PrevEnabled)
				{
					this._spotify.Previous();
				}
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "[SPOTIFY] Failed to execute 'Previous' command: {0}", ex.Message);
				this.UpdateInfoWithSpotifyConnection();
			}
		}

		private void Spotify_OnTrackChange(object sender, TrackChangeEventArgs e)
		{
			try
			{
				this.IsAdvert = e.NewTrack.IsAd();

				if (!this.IsAdvert)
				{
					this.Name = e.NewTrack.TrackResource.Name;
					this.Artist = e.NewTrack.ArtistResource.Name;
					this.Album = e.NewTrack.AlbumResource.Name;
					this.AlbumArt = (BitmapSource)new ImageSourceConverter().ConvertFrom(e.NewTrack.GetAlbumArtAsByteArray(AlbumArtSize.Size640));
					this.Length = e.NewTrack.Length;
				}
				else
				{
					this.GetSpotifyTrack();
				}
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "[SPOTIFY] Failed to update on track change event: {0}", ex.Message);
			}
		}

		private void Spotify_OnTrackTimeChange(object sender, TrackTimeChangeEventArgs e)
		{
			try
			{
				this.TrackProgression = e.TrackTime;
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "[SPOTIFY] Failed to update on track time change event: {0}", ex.Message);
			}
		}

		private void Spotify_OnPlayStateChange(object sender, PlayStateEventArgs e)
		{
			try
			{
				this.IsPlaying = e.Playing;
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "[SPOTIFY] Failed to update on play state change event: {0}", ex.Message);
			}
		}

		private void GetSpotifyTrack()
		{
			try
			{
				Retry.AttemptWithRetries<Exception>(5, TimeSpan.FromSeconds(10), () =>
				{
					if (this._spotify.Connect())
					{
						if (!this._spotify.GetStatus().Track.IsAd())
						{
							this.Name = this._spotify.GetStatus().Track.TrackResource.Name;
							this.Artist = this._spotify.GetStatus().Track.ArtistResource.Name;
							this.Album = this._spotify.GetStatus().Track.AlbumResource.Name;
							this.AlbumArt = (BitmapSource)new ImageSourceConverter().ConvertFrom(this._spotify.GetStatus().Track.GetAlbumArtAsByteArray(AlbumArtSize.Size640));
							this.Length = this._spotify.GetStatus().Track.Length;
							this.IsPlaying = this._spotify.GetStatus().Playing;
							this.IsAdvert = false;
						}
						else
						{
							this.Name = @"Advertisment";
							this.Artist = @"¯\_(ツ)_/¯";
							this.Album = @"¯\_(ツ)_/¯";
							this.AlbumArt = null;
							this.Length = 0;
							this.TrackProgression = 0;
							this.IsPlaying = this._spotify.GetStatus().Playing;
							this.IsAdvert = true;
						}
					}
					else
					{
						throw new Exception("Failed to connect to Spotify");
					}
				});
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "[SPOTIFY] Failed to get Spotify track: {0}", ex.Message);
			}
		}

		private void UpdateInfoWithSpotifyConnection()
		{
			if (!this._spotify.Connect())
			{
				this.Name = "Smallify";
				this.Artist = this.dummyStringList.PickRandom();
				this.Album = "No connection";
				this.AlbumArt = null;
				this.TrackProgression = 0;
				this.Length = 0;
				this.IsPlaying = false;
				this.IsAdvert = false;
			}
		}

		private async void LaunchSpotify()
		{
			if (!SpotifyLocalAPI.IsSpotifyRunning())
			{
				SpotifyLocalAPI.RunSpotify();
				await Task.Delay(TimeSpan.FromSeconds(5));
			}
		}

		private async void LaunchSpotifyWebHelper()
		{
			if (!SpotifyLocalAPI.IsSpotifyWebHelperRunning())
			{
				SpotifyLocalAPI.RunSpotifyWebHelper();
				await Task.Delay(TimeSpan.FromSeconds(5));
			}
		}
	}
}
