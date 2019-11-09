using Prism.Mvvm;
using Smallify.Core.Configuration;

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

        public AuthenticationSectionViewModel(AuthenticationSettings settings)
        {
            _settings = settings;
            _accessToken = settings.AccessToken;
        }
    }
}
