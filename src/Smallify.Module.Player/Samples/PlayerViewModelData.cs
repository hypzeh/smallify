using Smallify.Module.Player.ViewModels;
using System.Windows.Input;

namespace Smallify.Module.Player.Samples
{
	public class PlayerViewModelData : IPlayerViewModel
	{
		public ICommand PreviousCommand { get; }

		public ICommand PlayCommand { get; }

		public ICommand PauseCommand { get; }

		public ICommand SkipCommand { get; }

		public ICommand RefreshCommand { get; }

		public string TrackName
		{
			get => "Track Name";
			set => throw new System.NotImplementedException();
		}

		public string ArtistName
		{
			get => "Artist Name";
			set => throw new System.NotImplementedException();
		}

		public string AlbumName
		{
			get => "Album Name";
			set => throw new System.NotImplementedException();
		}

		public string AlbumArtURL
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
