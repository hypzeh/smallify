using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Smallify.Core.Configuration;
using Smallify.Core.Spotify;
using System.ComponentModel;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
    internal class AuthenticationSectionViewModel : BindableBase
    {
        private readonly AuthenticationSettings _settings;
        private readonly SpotifyService _spotify;
        private string _authorisationCode;
        private string _displayName;
        private string _username;

        public string AuthorisationCode
        {
            get => _authorisationCode;
            set => SetProperty(ref _authorisationCode, value);
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
        public string ClientID { get => _settings.ClientID; }
        public string ClientSecret { get => _settings.ClientSecret; }
        public ICommand GetAuthenticationCodeCommand { get; }
        public ICommand GetUserCommand { get; }


        public AuthenticationSectionViewModel(IEventAggregator eventAggregator, AuthenticationSettings settings, SpotifyService spotify)
        {
            _settings = settings;
            _spotify = spotify;
            _authorisationCode = settings.AuthorisationCode;
            _displayName = string.Empty;
            _username = string.Empty;

            _settings.PropertyChanged += Settings_PropertyChanged;

            GetAuthenticationCodeCommand = new DelegateCommand(GetAuthenticationCodeCommand_Execute);
            GetUserCommand = new DelegateCommand(GetUserCommand_Execute);
            GetUserCommand.Execute(null);
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != nameof(AuthenticationSettings.AuthorisationCode))
            {
                return;
            }

            AuthorisationCode = _settings.AuthorisationCode;
            if (string.IsNullOrEmpty(AuthorisationCode))
            {
                DisplayName = string.Empty;
                Username = string.Empty;
                return;
            }

            GetUserCommand.Execute(null);
        }

        private void GetAuthenticationCodeCommand_Execute()
        {
            _spotify.OpenBrowser();
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
