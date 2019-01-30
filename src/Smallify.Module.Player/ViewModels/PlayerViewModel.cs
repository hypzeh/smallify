using Prism.Commands;
using Prism.Mvvm;
using Smallify.Module.Player.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smallify.Module.Player.ViewModels
{
	public class PlayerViewModel : BindableBase, IPlayerViewModel
	{
		private readonly ISpotifyService _spotifyService;

		private string _trackName;
		private string _artistName;
		private string _albumName;
		private string _albumArtURL;
		private bool _isPlaying;

		public PlayerViewModel(ISpotifyService spotifyService)
		{
			_spotifyService = spotifyService;

			_trackName = "Track Name";
			_artistName = "Artist Name";
			_albumName = "Album Name";
			_albumArtURL = string.Empty;
			_isPlaying = false;

			PreviousCommand = new DelegateCommand(PreviousCommand_Execute);
			PlayCommand = new DelegateCommand(PlayCommand_Execute);
			PauseCommand = new DelegateCommand(PauseCommand_Execute);
			SkipCommand = new DelegateCommand(SkipCommand_Execute);
			RefreshCommand = new DelegateCommand<TimeSpan?>(RefreshCommand_Execute);

			RefreshCommand.Execute(null);
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

		public string ArtistName
		{
			get => _artistName;
			set => SetProperty(ref _artistName, value);
		}

		public string AlbumName
		{
			get => _albumName;
			set => SetProperty(ref _albumName, value);
		}

		public string AlbumArtURL
		{
			get => _albumArtURL;
			set => SetProperty(ref _albumArtURL, value);
		}

		public bool IsPlaying
		{
			get => _isPlaying;
			set => SetProperty(ref _isPlaying, value);
		}

		private async void PreviousCommand_Execute()
		{
			if (false == await _spotifyService.TryPreviousAsync())
			{
				return;
			}


			RefreshCommand.Execute(TimeSpan.FromSeconds(1d));
		}

		private async void PlayCommand_Execute()
		{
			if (false == await _spotifyService.TryPlayAsync())
			{
				return;
			}

			IsPlaying = true;
			RefreshCommand.Execute(TimeSpan.FromSeconds(1d));
		}

		private async void PauseCommand_Execute()
		{
			if (false == await _spotifyService.TryPauseAsync())
			{
				return;
			}

			IsPlaying = false;
			RefreshCommand.Execute(TimeSpan.FromSeconds(1d));
		}

		private async void SkipCommand_Execute()
		{
			if (false == await _spotifyService.TrySkipAsync())
			{
				return;
			}

			RefreshCommand.Execute(TimeSpan.FromSeconds(1d));
		}

		private async void RefreshCommand_Execute(TimeSpan? delay = null)
		{
			if (delay.HasValue)
			{
				await Task.Delay(delay.Value);
			}

			var context = await _spotifyService.GetPlaybackStateAsync();
			if (context == null)
			{
				return;
			}

			IsPlaying = context.IsPlaying;
			TrackName = context.Item.Name;
			ArtistName = string.Join(", ", context.Item.Artists.Select(artist => artist.Name));
			AlbumName = context.Item.Album.Name;
			AlbumArtURL = context.Item.Album.Images.ElementAt(1)?.Url;
		}
	}
}
