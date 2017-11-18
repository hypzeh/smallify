using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace Smallify.Interfaces
{
	public interface ITrack : INotifyPropertyChanged
	{
		string Name { get; }

		string Artist { get; }

		string Album { get; }

		BitmapSource AlbumArt { get; }

		int Length { get; }

		double TrackProgression { get; }

		bool IsPlaying { get; }

		bool CanExecute { get; }

		void PlayPause();

		void Skip();

		void Previous();
	}
}
