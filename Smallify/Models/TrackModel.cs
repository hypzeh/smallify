using Microsoft.Practices.Prism.Mvvm;
using Smallify.Interfaces;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Enums;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Smallify.Models
{
	public class TrackModel : BindableBase, ITrack
	{
		private readonly SpotifyLocalAPI _spotify;

		private string _name;
		private string _artist;
		private string _album;
		private BitmapSource _albumArt;
		private int _length;
		private double _trackProgression;
		private bool _isPlaying;

		public TrackModel()
		{
			this._spotify = new SpotifyLocalAPI();

			if (this._spotify.Connect())
			{
				this._spotify.OnTrackChange += this.Spotify_OnTrackChange;
				this._spotify.OnTrackTimeChange += this.Spotify_OnTrackTimeChange;
				this._spotify.OnPlayStateChange += this.Spotify_OnPlayStateChange;

				this._spotify.ListenForEvents = true;

				this.Name = this._spotify.GetStatus().Track.TrackResource.Name;
				this.Artist = this._spotify.GetStatus().Track.ArtistResource.Name;
				this.Album = this._spotify.GetStatus().Track.AlbumResource.Name;
				this.AlbumArt = (BitmapSource)new ImageSourceConverter().ConvertFrom(this._spotify.GetStatus().Track.GetAlbumArtAsByteArray(AlbumArtSize.Size640));
				this.Length = this._spotify.GetStatus().Track.Length;
				this.IsPlaying = this._spotify.GetStatus().Playing;
			}
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

		public void PlayPause()
		{
			if (this.IsPlaying)
			{
				this._spotify.Pause();
			}
			else
			{
				this._spotify.Play();
			}
		}

		public void Skip()
		{
			this._spotify.Skip();
		}

		public void Previous()
		{
			this._spotify.Previous();
		}

		private void Spotify_OnTrackChange(object sender, TrackChangeEventArgs e)
		{
			this.Name = e.NewTrack.TrackResource.Name;
			this.Artist = e.NewTrack.ArtistResource.Name;
			this.Album = e.NewTrack.AlbumResource.Name;
			this.AlbumArt = (BitmapSource)new ImageSourceConverter().ConvertFrom(e.NewTrack.GetAlbumArtAsByteArray(AlbumArtSize.Size640));
			this.Length = e.NewTrack.Length;
		}

		private void Spotify_OnTrackTimeChange(object sender, TrackTimeChangeEventArgs e)
		{
			this.TrackProgression = e.TrackTime;
		}

		private void Spotify_OnPlayStateChange(object sender, PlayStateEventArgs e)
		{
			this.IsPlaying = e.Playing;
		}
	}
}
