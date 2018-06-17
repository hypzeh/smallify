using GUI.Shared.Constants;
using Player.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.ComponentModel;
using System.Windows.Input;

namespace GUI.ViewModels
{
	public class ShellViewModel : BindableBase
	{
		private readonly IRegionManager _regionManager;
		private readonly PlayerModel _player;

		private string _title;

		public ShellViewModel(IRegionManager regionManager, PlayerModel player)
		{
			this._regionManager = regionManager;
			this._player = player;

			this._title = $"{this._player?.CurrentTrack?.TrackResource?.Name ?? "Smallify"} - {this._player?.CurrentTrack?.ArtistResource?.Name ?? string.Empty}";

			this._player.PropertyChanged += this.Player_PropertyChanged;

			this.SwitchPlayerCommand = new DelegateCommand<string>(this.SwitchPlayerCommand_Execute);
		}

		public ICommand SwitchPlayerCommand { get; private set; }

		public string Title
		{
			get
			{
				return this._title;
			}

			set
			{
				this.SetProperty(ref this._title, value);
			}
		}

		public void SwitchPlayerCommand_Execute(string playerRequest)
		{
			this._regionManager.RequestNavigate(RegionNames.PlayerRegion, playerRequest);
		}

		private void Player_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(this._player.CurrentTrack):
					var status = this._player.GetClientStatus();

					this.Title = $"{status?.Track?.TrackResource?.Name ?? "Smallify"} - {status?.Track?.ArtistResource?.Name ?? string.Empty}";
					
					break;
			}
		}
	}
}