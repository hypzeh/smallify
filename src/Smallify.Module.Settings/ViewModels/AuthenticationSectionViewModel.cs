using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Smallify.Core.Configuration;
using Smallify.Core.Events.Notifications;
using Smallify.Core.Spotify;
using System;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
    internal class AuthenticationSectionViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly AuthenticationSettings _settings;
        private readonly SpotifyService _spotify;
        private string _displayName;
        private string _username;

        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        public ICommand RequestAuthenticationCodeCommand { get; }
        public ICommand GetAuthenticationCodeFromClipboardCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand GetUserCommand { get; }


        public AuthenticationSectionViewModel(IEventAggregator eventAggregator, AuthenticationSettings settings, SpotifyService spotify)
        {
            _eventAggregator = eventAggregator;
            _settings = settings;
            _spotify = spotify;
            _displayName = string.Empty;
            _username = string.Empty;

            RequestAuthenticationCodeCommand = new DelegateCommand(RequestAuthenticationCodeCommand_Execute);
            GetAuthenticationCodeFromClipboardCommand = new DelegateCommand(GetAuthenticationCodeFromClipboardCommand_Execute);
            LogoutCommand = new DelegateCommand(LogoutCommand_Execute);
            GetUserCommand = new DelegateCommand(GetUserCommand_Execute);
            GetUserCommand.Execute(null);
        }

        private void RequestAuthenticationCodeCommand_Execute()
        {
            _spotify.OpenBrowser();
        }

        private async void GetAuthenticationCodeFromClipboardCommand_Execute()
        {
            var token = await _spotify.ExchangeAccessCodeAsync(Clipboard.GetText()).ConfigureAwait(false);
            if (token.HasError())
            {
                _eventAggregator.GetEvent<OnNotificationCreatedEvent>()?.Publish(token.ErrorDescription);
                return;
            }

            GetUserCommand.Execute(null);
        }

        private void LogoutCommand_Execute()
        {
            _settings.SetToken(new AuthenticationToken(string.Empty, string.Empty, 0, DateTimeOffset.UtcNow));
            DisplayName = string.Empty;
            Username = string.Empty;
        }

        private async void GetUserCommand_Execute()
        {
            var user = await _spotify.GetCurrentUserAsync().ConfigureAwait(false);
            if (user.HasError())
            {
                _eventAggregator.GetEvent<OnNotificationCreatedEvent>()?.Publish(user.Error.Message);
                return;
            }

            DisplayName = user.DisplayName;
            Username = user.Id;
        }
    }
}
