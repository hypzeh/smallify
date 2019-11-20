using Prism.Commands;
using Prism.Mvvm;
using Smallify.Core.Configuration;
using Smallify.Core.Spotify;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
    internal class AuthenticationSectionViewModel : BindableBase
    {
        private readonly AuthenticationSettings _settings;
        private readonly SpotifyService _spotify;
        private string _authenticationCode;
        private string _displayName;
        private string _username;

        public string AuthenticationCode
        {
            get => _authenticationCode;
            set => SetProperty(ref _authenticationCode, value);
        }
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
        public ICommand GetAuthenticationCodeFromClipboard { get; }
        public ICommand GetUserCommand { get; }


        public AuthenticationSectionViewModel(AuthenticationSettings settings, SpotifyService spotify)
        {
            _settings = settings;
            _spotify = spotify;
            _authenticationCode = settings.AuthorisationCode;
            _displayName = string.Empty;
            _username = string.Empty;

            _settings.PropertyChanged += Settings_PropertyChanged;

            RequestAuthenticationCodeCommand = new DelegateCommand(RequestAuthenticationCodeCommand_Execute);
            GetAuthenticationCodeFromClipboard = new DelegateCommand(GetAuthenticationCodeFromClipboard_Execute);
            GetUserCommand = new DelegateCommand(GetUserCommand_Execute);
            GetUserCommand.Execute(null);
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != nameof(AuthenticationSettings.AuthorisationCode))
            {
                return;
            }

            AuthenticationCode = _settings.AuthorisationCode;
            if (string.IsNullOrEmpty(AuthenticationCode))
            {
                DisplayName = string.Empty;
                Username = string.Empty;
                return;
            }

            GetUserCommand.Execute(null);
        }

        private void RequestAuthenticationCodeCommand_Execute()
        {
            _spotify.OpenBrowser();
        }

        private void GetAuthenticationCodeFromClipboard_Execute()
        {
            var code = Clipboard.GetText();
            if (string.IsNullOrEmpty(code))
            {
                return;
            }

            _settings.SetAuthorisationCode(code);
        }

        private async void GetUserCommand_Execute()
        {
            var user = await _spotify.GetCurrentUserAsync().ConfigureAwait(false);
            if (user.HasError())
            {
                return;
            }

            DisplayName = user.DisplayName;
            Username = user.Id;
        }
    }
}
