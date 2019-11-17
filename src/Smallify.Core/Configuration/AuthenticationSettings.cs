using Jot;
using Jot.Configuration;
using System;
using System.ComponentModel;

namespace Smallify.Core.Configuration
{
    public class AuthenticationSettings : ITrackingAware<AuthenticationSettings>, INotifyPropertyChanged
    {
        public string ClientID { get; }
        public string ClientSecret { get; }
        public string AuthorisationCode { get; private set; }
        public AuthenticationToken Token { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public AuthenticationSettings(string clientId, string clientSecret)
        {
            ClientID = clientId;
            ClientSecret = clientSecret;
            AuthorisationCode = string.Empty;
            Token = new AuthenticationToken(
                accessToken: string.Empty,
                refreshToken: string.Empty,
                expiryLength: 0,
                timestamp: DateTimeOffset.UtcNow);

            new Tracker().Track(this);
        }
        public void SetAuthorisationCode(string authorisationCode)
        {
            AuthorisationCode = authorisationCode;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AuthorisationCode)));
        }

        public void SetToken(AuthenticationToken token)
        {
            Token = token;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Token)));
        }

        public void ConfigureTracking(TrackingConfiguration<AuthenticationSettings> configuration)
        {
            configuration.Properties(settings =>
            new
            {
                settings.AuthorisationCode,
                settings.Token,
            });
            PropertyChanged += (sender, args) => { configuration.Tracker.Persist(this); };
        }
    }
}
