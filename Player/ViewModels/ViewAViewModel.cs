using Player.Models;
using Prism.Mvvm;
using System.ComponentModel;

namespace Player.ViewModels
{
	public class ViewAViewModel : BindableBase
	{
		private readonly PlayerModel _player;

		private bool _isConnected;

		public ViewAViewModel(PlayerModel player)
		{
			this._player = player;

			this._player.ConnectToSpotify();

			this._isConnected = this._player.IsConnected;

			this._player.PropertyChanged += this.Player_PropertyChanged;
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

		private void Player_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(this._player.IsConnected):
					this.IsConnected = this._player.IsConnected;
					break;
			}
		}
	}
}