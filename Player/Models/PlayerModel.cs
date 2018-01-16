using SpotifyAPI.Local;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Player.Models
{
	public class PlayerModel : IDisposable, INotifyPropertyChanged
	{
		private readonly SpotifyLocalAPI _spotify;

		public PlayerModel()
		{
			this._spotify = new SpotifyLocalAPI();
		}

		public event PropertyChangedEventHandler PropertyChanged;

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