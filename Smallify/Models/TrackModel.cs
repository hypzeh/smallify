using Microsoft.Practices.Prism.Mvvm;
using NLog;
using Smallify.Extensions;
using Smallify.Interfaces;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Smallify.Models
{
	public class TrackModel : BindableBase, ITrack
	{
		private static Logger GetLogger = LogManager.GetCurrentClassLogger();

		private readonly SpotifyLocalAPI _spotify;
		private readonly List<string> _dummyStringList;

		private string _name;
		private string _artist;
		private string _album;
		private BitmapSource _albumArt;
		private int _length;
		private double _trackProgression;
		private bool _isPlaying;
		private bool _canExecute;

		public TrackModel()
		{
			this._spotify = new SpotifyLocalAPI();

			this._dummyStringList = new List<string>
			{
				@"Wherefore art thou Spotify? >:(",
				@"¯\_(ツ)_/¯"
			};

			this.Name = "Smallify";
			this.Artist = this._dummyStringList.PickRandom();

			this.GetSpotifyTrack();

			this._spotify.OnTrackChange += this.Spotify_OnTrackChange;
			this._spotify.OnTrackTimeChange += this.Spotify_OnTrackTimeChange;
			this._spotify.OnPlayStateChange += this.Spotify_OnPlayStateChange;

			this._spotify.ListenForEvents = true;
		}

		public string Name
		{
			get
			{
				return this._name;
			}

			private set
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

			private set
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

			private set
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

			private set
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

			private set
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

			private set
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

			private set
			{
				this.SetProperty<bool>(ref this._isPlaying, value);
				this.OnPropertyChanged(nameof(this.IsPlaying));
			}
		}

		public bool CanExecute
		{
			get
			{
				return this._canExecute;
			}

			private set
			{
				this.SetProperty<bool>(ref this._canExecute, value);
				this.OnPropertyChanged(nameof(this.CanExecute));
			}
		}

		public void PlayPause()
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
					this.CanExecute = true;
				}
				else
				{
					this.CanExecute = false;
				}
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "[SPOTIFY] Failed to execute 'Play/Pause' command: {0}", ex.Message);
				this.CanExecute = false;
			}
		}

		public void Skip()
		{
			try
			{
				if (this._spotify.GetStatus().NextEnabled)
				{
					this._spotify.Skip();
					this.CanExecute = true;
				}
				else
				{
					this.CanExecute = false;
				}
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "[SPOTIFY] Failed to execute 'Skip' command: {0}", ex.Message);
				this.CanExecute = false;
			}
		}

		public void Previous()
		{
			try
			{
				if (this._spotify.GetStatus().PrevEnabled)
				{
					this._spotify.Previous();
					this.CanExecute = true;
				}
				else
				{
					this.CanExecute = false;
				}
			}
			catch (Exception ex)
			{

				GetLogger.Error(ex, "[SPOTIFY] Failed to execute 'Previous' command: {0}", ex.Message);
				this.CanExecute = false;
			}
		}

		private void Spotify_OnTrackChange(object sender, TrackChangeEventArgs e)
		{
			try
			{
				this.Name = e.NewTrack.TrackResource.Name;
				this.Artist = e.NewTrack.ArtistResource.Name;
				this.Album = e.NewTrack.AlbumResource.Name;
				this.AlbumArt = (BitmapSource)new ImageSourceConverter().ConvertFrom(e.NewTrack.GetAlbumArtAsByteArray(AlbumArtSize.Size640));
				this.Length = e.NewTrack.Length;
				this.CanExecute = true;
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "[SPOTIFY] Failed to update on track change event: {0}", ex.Message);
				this.CanExecute = false;
			}
		}

		private void Spotify_OnTrackTimeChange(object sender, TrackTimeChangeEventArgs e)
		{
			try
			{
				this.TrackProgression = e.TrackTime;
				this.CanExecute = true;
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "[SPOTIFY] Failed to update on track time change event: {0}", ex.Message);
				this.CanExecute = false;
			}
		}

		private void Spotify_OnPlayStateChange(object sender, PlayStateEventArgs e)
		{
			try
			{
				this.IsPlaying = e.Playing;
				this.CanExecute = true;
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "[SPOTIFY] Failed to update on play state change event: {0}", ex.Message);
				this.CanExecute = false;
			}
		}

		private void GetSpotifyTrack()
		{
			try
			{
				if (this._spotify.Connect())
				{
					this.Name = this._spotify.GetStatus().Track.TrackResource.Name;
					this.Artist = this._spotify.GetStatus().Track.ArtistResource.Name;
					this.Album = this._spotify.GetStatus().Track.AlbumResource.Name;
					this.AlbumArt = (BitmapSource)new ImageSourceConverter().ConvertFrom(this._spotify.GetStatus().Track.GetAlbumArtAsByteArray(AlbumArtSize.Size640));
					this.Length = this._spotify.GetStatus().Track.Length;
					this.IsPlaying = this._spotify.GetStatus().Playing;
					this.CanExecute = true;
				}
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "[SPOTIFY] Failed to get Spotify track: {0}", ex.Message);
				this.CanExecute = false;
			}
		}
	}
}
