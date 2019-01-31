using System.Windows.Input;

namespace Smallify.Module.Player.ViewModels
{
	public interface IPlayerViewModel
	{
		ICommand PreviousCommand { get; }

		ICommand PlayCommand { get; }

		ICommand PauseCommand { get; }

		ICommand SkipCommand { get; }

		ICommand RefreshCommand { get; }

		string TrackName { get; set; }

		string ArtistName { get; set; }

		string AlbumName { get; set; }

		string AlbumArtURL { get; set; }

		bool IsPlaying { get; set; }
	}
}