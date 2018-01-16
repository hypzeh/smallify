using SpotifyAPI.Local;
using SpotifyAPI.Local.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Player.Models
{
	public class PlayerModel : IDisposable, INotifyPropertyChanged
	{
		private readonly DispatcherTimer _heartbeatTimer;
		private readonly SpotifyLocalAPI _spotify;

		private Track _currentTrack;
		private bool _isConnected;
		private double _trackTime;

		public PlayerModel()
		{
			this._spotify = new SpotifyLocalAPI();
			this._heartbeatTimer = new DispatcherTimer(DispatcherPriority.DataBind)
			{
				Interval = TimeSpan.FromSeconds(10d)
			};

			this._currentTrack = new Track();
			this._trackTime = 0d;
			this._isConnected = false;

			this._heartbeatTimer.Tick += this.HeartbeatTimer_Tick;
			this._heartbeatTimer.Start();

			this._spotify.OnTrackChange += this.Spotify_OnTrackChange;
			this._spotify.OnTrackTimeChange += this.Spotify_OnTrackTimeChange;
			this._spotify.ListenForEvents = true;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public Track CurrentTrack
		{
			get
			{
				return this._currentTrack;
			}

			private set
			{
				if (value != this._currentTrack)
				{
					this._currentTrack = value;
					this.NotifyPropertyChanged(nameof(this.CurrentTrack));
				}
			}
		}

		public bool IsConnected
		{
			get
			{
				return this._isConnected;
			}

			private set
			{
				if (value != this._isConnected)
				{
					this._isConnected = value;
					this.NotifyPropertyChanged(nameof(this.IsConnected));
				}
			}
		}

		public double TrackTime
		{
			get
			{
				return this._trackTime;
			}

			private set
			{
				if (value != this._trackTime)
				{
					this._trackTime = value;
				}
			}
		}

		public void ConnectToSpotify()
		{
			if (this._spotify.Connect())
			{
				var status = this._spotify.GetStatus();

				this.IsConnected = status.Online;
			}
			else
			{
				this.IsConnected = false;
			}
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		public StatusResponse GetClientStatus()
		{
			return this._spotify.GetStatus();
		}

		public async Task Pause()
		{
			await this._spotify.Pause();
		}

		public async Task Play()
		{
			await this._spotify.Play();
		}

		public void Previous()
		{
			this._spotify.Previous();
		}

		public void Skip()
		{
			this._spotify.Skip();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._spotify.Dispose();
				this._spotify.OnTrackChange -= this.Spotify_OnTrackChange;
				this._spotify.OnTrackTimeChange -= this.Spotify_OnTrackTimeChange;

				this._heartbeatTimer.Stop();
				this._heartbeatTimer.Tick -= this.HeartbeatTimer_Tick;
			}
		}

		protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void HeartbeatTimer_Tick(object sender, EventArgs e)
		{
			this.ConnectToSpotify();
		}

		private void Spotify_OnTrackChange(object sender, TrackChangeEventArgs e)
		{
			this.CurrentTrack = e.NewTrack;
		}

		private void Spotify_OnTrackTimeChange(object sender, TrackTimeChangeEventArgs e)
		{
			this.TrackTime = e.TrackTime;
		}
	}
}