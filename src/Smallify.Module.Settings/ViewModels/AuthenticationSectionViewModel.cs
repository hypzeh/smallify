using Prism.Mvvm;
using Smallify.Core.Configuration;
using System.ComponentModel;

namespace Smallify.Module.Settings.ViewModels
{
    internal class AuthenticationSectionViewModel : BindableBase
    {
        private readonly AuthenticationSettings _settings;
        private string _authorisationCode;

        public string AuthorisationCode
        {
            get => _authorisationCode;
            set => SetProperty(ref _authorisationCode, value);
        }
        public string ClientID => _settings.ClientID;
        public string ClientSecret => _settings.ClientSecret;


        public AuthenticationSectionViewModel(AuthenticationSettings settings)
        {
            _settings = settings;
            _authorisationCode = settings.AuthorisationCode;

            _settings.PropertyChanged += Settings_PropertyChanged;
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != nameof(AuthenticationSettings.AuthorisationCode))
            {
                return;
            }

            AuthorisationCode = _settings.AuthorisationCode;
        }
    }
}
