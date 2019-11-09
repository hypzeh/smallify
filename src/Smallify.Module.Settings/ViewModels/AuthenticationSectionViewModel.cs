using Prism.Mvvm;
using Smallify.Core.Configuration;
using System.ComponentModel;

namespace Smallify.Module.Settings.ViewModels
{
    internal class AuthenticationSectionViewModel : BindableBase
    {
        private readonly AuthenticationSettings _settings;
        private string _accessToken;

        public string AccessToken
        {
            get => _accessToken;
            set => SetProperty(ref _accessToken, value);
        }
        public string ClientID => _settings.ClientID;
        public string ClientSecret => _settings.ClientSecret;


        public AuthenticationSectionViewModel(AuthenticationSettings settings)
        {
            _settings = settings;
            _accessToken = settings.AccessToken;

            _settings.PropertyChanged += Settings_PropertyChanged;
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AuthenticationSettings.AccessToken))
            {
                AccessToken = _settings.AccessToken;
            }
        }
    }
}
