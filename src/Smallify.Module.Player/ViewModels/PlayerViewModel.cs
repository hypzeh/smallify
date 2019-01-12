using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace Smallify.Module.Player.ViewModels
{
	public class PlayerViewModel : BindableBase, IPlayerViewModel
	{
		private string _trackName;
		private string _trackArtist;
		private string _trackAlbumName;
		private string _trackAlbumArtURL;
		private bool _isPlaying;

		public PlayerViewModel()
		{
			_trackName = "Track Name";
			_trackArtist = "Artist Name";
			_trackAlbumName = "Album Name";
			_trackAlbumArtURL = string.Empty;
			_isPlaying = false;

			PreviousCommand = new DelegateCommand(PreviousCommand_Execute);
			PlayCommand = new DelegateCommand(PlayCommand_Execute);
			PauseCommand = new DelegateCommand(PauseCommand_Execute);
			SkipCommand = new DelegateCommand(SkipCommand_Execute);
		}

		public ICommand PreviousCommand { get; private set; }

		public ICommand PlayCommand { get; private set; }

		public ICommand PauseCommand { get; private set; }

		public ICommand SkipCommand { get; private set; }

		public string TrackName
		{
			get => _trackName;
			set => SetProperty(ref _trackName, value);
		}

		public string TrackArtist
		{
			get => _trackArtist;
			set => SetProperty(ref _trackArtist, value);
		}

		public string TrackAlbumName
		{
			get => _trackAlbumName;
			set => SetProperty(ref _trackAlbumName, value);
		}

		public string TrackAlbumArtURL
		{
			get => _trackAlbumArtURL;
			set => SetProperty(ref _trackAlbumArtURL, value);
		}

		public bool IsPlaying
		{
			get => _isPlaying;
			set => SetProperty(ref _isPlaying, value);
		}

		private void PreviousCommand_Execute()
		{
			throw new NotImplementedException();
		}

		private void PlayCommand_Execute()
		{
			IsPlaying = true;
		}

		private void PauseCommand_Execute()
		{
			IsPlaying = false;
		}

		private void SkipCommand_Execute()
		{
			throw new NotImplementedException();
		}
	}
}
