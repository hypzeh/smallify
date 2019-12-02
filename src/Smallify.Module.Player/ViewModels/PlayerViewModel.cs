using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Smallify.Core.Events.Authentication;
using Smallify.Core.Events.Notifications;
using Smallify.Core.Spotify;
using Smallify.Core.Spotify.Models;
using System;
using System.Timers;
using System.Windows.Input;

namespace Smallify.Module.Player.ViewModels
{
    internal class PlayerViewModel : BindableBase, IDisposable
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
            _eventAggregator.GetEvent<OnLoginEvent>()?.Subscribe(OnLoginEvent_Published);
            _eventAggregator.GetEvent<OnLogoutEvent>()?.Subscribe(OnLogoutEvent_Published);

            GetPlaybackCommand.Execute(null);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _playback.Elapsed -= Playback_Elapsed;
                _playback.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private async void GetPlaybackCommand_Execute()
        {
            UpdatePlayback(await _spotify.GetPlaybackAsync().ConfigureAwait(true));
        }

        private async void PlayCommand_Execute()
        {
            UpdatePlayback(await _spotify.ResumePlaybackAsync().ConfigureAwait(true));
        }

        private async void PauseCommand_Execute()
        {
            UpdatePlayback(await _spotify.PausePlaybackAsync().ConfigureAwait(true));
        }

        private async void SkipCommand_Execute()
        {
            UpdatePlayback(await _spotify.SkipPlaybackAsync().ConfigureAwait(true));
        }

        private async void PreviousCommand_Execute()
        {
            UpdatePlayback(await _spotify.PreviousPlaybackAsync().ConfigureAwait(true));
        }

        private void UpdatePlayback(PlaybackResponse playback)
        {
            if (playback.HasError())
            {
                DispatchNotification(playback.ErrorMessage);
                return;
            }

            Name = playback.Track.Name;
            Artist = playback.Track.Artist;
            Album = playback.Track.Album;
            AlbumArt = playback.Track.AlbumArt;
            IsPlaying = playback.IsPlaying;

            if (!playback.IsPlaying)
            {
                return;
            }

            _playback.Interval = (playback.Track.Duration - playback.Progress) + 100;
            _playback.Start();
        }

        private void Playback_Elapsed(object sender, ElapsedEventArgs args)
        {
            GetPlaybackCommand.Execute(null);
        }

        private void OnLoginEvent_Published()
        {
            GetPlaybackCommand.Execute(null);
        }

        private void OnLogoutEvent_Published()
        {
            _playback.Stop();
            Name = string.Empty;
            Artist = string.Empty;
            Album = string.Empty;
            AlbumArt = string.Empty;
            IsPlaying = false;
        }

        private void DispatchNotification(string notification)
        {
            _eventAggregator.GetEvent<OnNotificationCreatedEvent>()?.Publish(notification);
        }
    }
}
