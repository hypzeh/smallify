using Jot;
using Jot.Configuration;
using System.ComponentModel;

namespace Smallify.Core.Configuration
{
    public class AuthenticationSettings : ITrackingAware<AuthenticationSettings>, INotifyPropertyChanged
    {
        public string ClientID { get; }
        public string ClientSecret { get; }
        public string AuthorisationCode { get; private set; }
        public string AccessToken { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public AuthenticationSettings(string clientId, string clientSecret)
        {
            ClientID = clientId;
            ClientSecret = clientSecret;
            AuthorisationCode = string.Empty;
            AccessToken = string.Empty;

            new Tracker().Track(this);
        }
        public void SetAuthorisationCode(string authorisationCode)
        {
            AuthorisationCode = authorisationCode;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AuthorisationCode)));
        }

        public void SetAccessToken(string accessToken)
        {
            AccessToken = accessToken;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AccessToken)));
        }

        public void ConfigureTracking(TrackingConfiguration<AuthenticationSettings> configuration)
        {
            configuration.Properties(settings => new { settings.AuthorisationCode, settings.AccessToken });
            PropertyChanged += (sender, args) => { configuration.Tracker.Persist(this); };
        }
    }
}
