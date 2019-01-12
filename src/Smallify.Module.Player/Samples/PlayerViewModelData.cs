using Smallify.Module.Player.ViewModels;
using System.Windows.Input;

namespace Smallify.Module.Player.Samples
{
	public class PlayerViewModelData : IPlayerViewModel
	{
		public ICommand PreviousCommand => throw new System.NotImplementedException();

		public ICommand PlayCommand => throw new System.NotImplementedException();

		public ICommand PauseCommand => throw new System.NotImplementedException();

		public ICommand SkipCommand => throw new System.NotImplementedException();

		public string TrackName
		{
			get => "Track Name";
			set => throw new System.NotImplementedException();
		}

		public string TrackArtist
		{
			get => "Artist Name";
			set => throw new System.NotImplementedException();
		}

		public string TrackAlbumName
		{
			get => "Album Name";
			set => throw new System.NotImplementedException();
		}

		public string TrackAlbumArtURL
		{
			get => "http://placekitten.com/150/150";
			set => throw new System.NotImplementedException();
		}

		public bool IsPlaying
		{
			get => true;
			set => throw new System.NotImplementedException();
		}
	}
}
