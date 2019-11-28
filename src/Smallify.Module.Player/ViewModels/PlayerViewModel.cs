using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Smallify.Core.Events.Notifications;
using Smallify.Core.Spotify;
using System.Timers;
using System.Windows.Input;

namespace Smallify.Module.Player.ViewModels
{
    internal class PlayerViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ISpotifyService _spotify;
        private readonly Timer _playback;
        private string _name;
        private string _artist;
        private string _album;
        private string _albumArt;
        private bool _isPlaying;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string Artist
        {
            get => _artist;
            set => SetProperty(ref _artist, value);
        }
        public string Album
        {
            get => _album;
            set => SetProperty(ref _album, value);
        }
        public string AlbumArt
        {
            get => _albumArt;
            set => SetProperty(ref _albumArt, value);
        }
        public bool IsPlaying
        {
            get => _isPlaying;
            set => SetProperty(ref _isPlaying, value);
        }
        public ICommand GetPlaybackCommand { get; }
        public ICommand PlayCommand { get; }
        public ICommand PauseCommand { get; }
        public ICommand SkipCommand { get; }
        public ICommand PreviousCommand { get; }

        public PlayerViewModel(IEventAggregator eventAggregator, ISpotifyService spotify)
        {
            _eventAggregator = eventAggregator;
            _spotify = spotify;
            _playback = new Timer
            {
                AutoReset = false
            };
            _name = string.Empty;
            _artist = string.Empty;
            _album = string.Empty;
            _albumArt = string.Empty;
            _isPlaying = false;

            GetPlaybackCommand = new DelegateCommand(GetPlaybackCommand_Execute);
            PlayCommand = new DelegateCommand(PlayCommand_Execute);
            PauseCommand = new DelegateCommand(PauseCommand_Execute);
            SkipCommand = new DelegateCommand(SkipCommand_Execute);
            PreviousCommand = new DelegateCommand(PreviousCommand_Execute);

            _playback.Elapsed += Playback_Elapsed;

            GetPlaybackCommand.Execute(null);
        }

        private async void GetPlaybackCommand_Execute()
        {
            var response = await _spotify.GetPlaybackAsync().ConfigureAwait(true);
            if (response.HasError())
            {
                DispatchNotification(response.ErrorMessage);
                return;
            }

            Name = response.Track.Name;
            Artist = response.Track.Artist;
            Album = response.Track.Album;
            AlbumArt = response.Track.AlbumArt;
            IsPlaying = response.IsPlaying;

            _playback.Interval = (response.Track.Duration - response.Progress) + 100;
            _playback.Start();
        }

        private async void PlayCommand_Execute()
        {
            var response = await _spotify.ResumePlaybackAsync().ConfigureAwait(true);
            if (response.HasError())
            {
                DispatchNotification(response.ErrorMessage);
                return;
            }

            IsPlaying = true;
        }

        private async void PauseCommand_Execute()
        {
            var response = await _spotify.PausePlaybackAsync().ConfigureAwait(true);
            if (response.HasError())
            {
                DispatchNotification(response.ErrorMessage);
                return;
            }

            IsPlaying = false;
        }

        private async void SkipCommand_Execute()
        {
            var response = await _spotify.SkipPlaybackAsync().ConfigureAwait(true);
            if (response.HasError())
            {
                DispatchNotification(response.ErrorMessage);
                return;
            }

            IsPlaying = true;
        }

        private async void PreviousCommand_Execute()
        {
            var response = await _spotify.PreviousPlaybackAsync().ConfigureAwait(true);
            if (response.HasError())
            {
                DispatchNotification(response.ErrorMessage);
                return;
            }

            IsPlaying = true;
        }

        private void Playback_Elapsed(object sender, ElapsedEventArgs args)
        {
            GetPlaybackCommand.Execute(null);
        }

        private void DispatchNotification(string notification)
        {
            _eventAggregator.GetEvent<OnNotificationCreatedEvent>()?.Publish(notification);
        }
    }
}
