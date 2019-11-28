namespace Smallify.Core.Spotify.Models
{
    public class TokenResponse : BasicResponse
    {
        public string AccessToken { get; }
        public string RefreshToken { get; }

        public TokenResponse(string errorMessage) : base(errorMessage)
        {
            AccessToken = string.Empty;
            RefreshToken = string.Empty;
        }

        public TokenResponse(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
