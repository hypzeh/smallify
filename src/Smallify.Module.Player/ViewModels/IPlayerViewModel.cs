using System.Windows.Input;

namespace Smallify.Module.Player.ViewModels
{
	public interface IPlayerViewModel
	{
		ICommand PreviousCommand { get; }

		ICommand PlayCommand { get; }

		ICommand PauseCommand { get; }

		ICommand SkipCommand { get; }

		string TrackName { get; set; }

		string TrackArtist { get; set; }

		string TrackAlbumName { get; set; }

		string TrackAlbumArtURL { get; set; }

		bool IsPlaying { get; set; }
	}
}