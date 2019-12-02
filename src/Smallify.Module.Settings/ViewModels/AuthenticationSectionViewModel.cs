using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Smallify.Core.Configuration;
using Smallify.Core.Events.Authentication;
using Smallify.Core.Events.Notifications;
using Smallify.Core.Spotify;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
    internal class AuthenticationSectionViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly AuthenticationSettings _settings;
        private readonly ISpotifyService _spotify;
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


        public AuthenticationSectionViewModel(IEventAggregator eventAggregator, AuthenticationSettings settings, ISpotifyService spotify)
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

            _settings.PropertyChanged += Settings_PropertyChanged;

            GetUserCommand.Execute(null);
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != nameof(AuthenticationSettings.Token))
            {
                return;
            }

            if (string.IsNullOrEmpty(_settings.Token.AccessToken))
            {
                DisplayName = string.Empty;
                Username = string.Empty;
            }
        }

        private void RequestAuthenticationCodeCommand_Execute()
        {
            _spotify.OpenBrowser();
        }

        private async void GetAuthenticationCodeFromClipboardCommand_Execute()
        {
            var token = await _spotify.ExchangeAccessCodeAsync(Clipboard.GetText()).ConfigureAwait(true);
            if (token.HasError())
            {
                _eventAggregator.GetEvent<OnNotificationCreatedEvent>()?.Publish(token.ErrorMessage);
                return;
            }

            _eventAggregator.GetEvent<OnLoginEvent>()?.Publish();
            GetUserCommand.Execute(null);
        }

        private void LogoutCommand_Execute()
        {
            _eventAggregator.GetEvent<OnLogoutEvent>()?.Publish();
            _settings.ClearToken();
        }

        private async void GetUserCommand_Execute()
        {
            var response = await _spotify.GetCurrentUserAsync().ConfigureAwait(true);
            if (response.HasError())
            {
                _eventAggregator.GetEvent<OnNotificationCreatedEvent>()?.Publish(response.ErrorMessage);
                return;
            }

            DisplayName = response.DisplayName;
            Username = response.Username;
        }
    }
}
