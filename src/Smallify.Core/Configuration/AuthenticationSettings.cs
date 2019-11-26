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
        public string RedirectURI { get; }
        public AuthenticationToken Token { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public AuthenticationSettings(string clientId, string clientSecret, string redirectURI)
        {
            ClientID = clientId;
            ClientSecret = clientSecret;
            RedirectURI = redirectURI;
            Token = new AuthenticationToken(
                accessToken: string.Empty,
                refreshToken: string.Empty,
                expiryLength: 0,
                timestamp: DateTimeOffset.UtcNow);

            new Tracker().Track(this);
        }

        public void SetToken(AuthenticationToken token)
        {
            Token = token;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Token)));
        }

        public void ClearToken()
        {
            SetToken(new AuthenticationToken(
                accessToken: string.Empty,
                refreshToken: string.Empty,
                expiryLength: 0,
                timestamp: DateTimeOffset.UtcNow));
        }

        public void ConfigureTracking(TrackingConfiguration<AuthenticationSettings> configuration)
        {
            configuration.Properties(settings => new { settings.Token });
            PropertyChanged += (sender, args) => { configuration.Tracker.Persist(this); };
        }
    }
}
