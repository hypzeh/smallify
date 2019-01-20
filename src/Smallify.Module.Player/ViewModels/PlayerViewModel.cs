using Prism.Commands;
using Prism.Mvvm;
using Smallify.Module.Player.Services;
using System.Linq;
using System.Windows.Input;

namespace Smallify.Module.Player.ViewModels
{
	public class PlayerViewModel : BindableBase, IPlayerViewModel
	{
		private readonly ISpotifyService _spotifyService;

		private string _trackName;
		private string _trackArtist;
		private string _trackAlbumName;
		private string _trackAlbumArtURL;
		private bool _isPlaying;

		public PlayerViewModel(ISpotifyService spotifyService)
		{
			_spotifyService = spotifyService;

			_trackName = "Track Name";
			_trackArtist = "Artist Name";
			_trackAlbumName = "Album Name";
			_trackAlbumArtURL = string.Empty;
			_isPlaying = false;

			PreviousCommand = new DelegateCommand(PreviousCommand_Execute);
			PlayCommand = new DelegateCommand(PlayCommand_Execute);
			PauseCommand = new DelegateCommand(PauseCommand_Execute);
			SkipCommand = new DelegateCommand(SkipCommand_Execute);
			RefreshCommand = new DelegateCommand(RefreshCommand_Execute);
		}

		public ICommand PreviousCommand { get; private set; }

		public ICommand PlayCommand { get; private set; }

		public ICommand PauseCommand { get; private set; }

		public ICommand SkipCommand { get; private set; }

		public ICommand RefreshCommand { get; private set; }

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

		private async void PreviousCommand_Execute()
		{
			await _spotifyService.PreviousAsync();
			if (!IsPlaying)
			{
				IsPlaying = true;
			}

			RefreshCommand.Execute(null);
		}

		private async void PlayCommand_Execute()
		{
			await _spotifyService.PlayAsync();
			IsPlaying = true;
		}

		private async void PauseCommand_Execute()
		{
			await _spotifyService.PauseAsync();
			IsPlaying = false;
		}

		private async void SkipCommand_Execute()
		{
			await _spotifyService.SkipAsync();
			if (!IsPlaying)
			{
				IsPlaying = true;
			}

			RefreshCommand.Execute(null);
		}

		private async void RefreshCommand_Execute()
		{
			var track = await _spotifyService.GetPlaybackStateAsync();
			TrackName = track.Name;
			TrackArtist = string.Join(", ", track.Artists.Select(artist => artist.Name));
			TrackAlbumName = track.Album.Name;
			TrackAlbumArtURL = track.Album.Images.LastOrDefault()?.Url;
		}
	}
}
