namespace Smallify.Core.Configuration
{
    public class AuthenticationSettings
    {
        public string ClientID { get; }
        public string ClientSecret { get; }
        public string AccessToken { get; private set; }

        public AuthenticationSettings(string clientId, string clientSecret)
        {
            ClientID = clientId;
            ClientSecret = clientSecret;
            AccessToken = string.Empty;
        }

        public void SetAccessToken(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
