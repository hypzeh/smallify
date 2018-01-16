using SpotifyAPI.Local;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Player.Models
{
	public class PlayerModel : IDisposable, INotifyPropertyChanged
	{
		private readonly SpotifyLocalAPI _spotify;

		private bool _isConnected;

		public PlayerModel()
		{
			this._spotify = new SpotifyLocalAPI();

			this._isConnected = false;
		}

		public event PropertyChangedEventHandler PropertyChanged;

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

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._spotify.Dispose();
			}
		}

		protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}