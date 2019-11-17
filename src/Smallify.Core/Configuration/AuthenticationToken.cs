using System;

namespace Smallify.Core.Configuration
{
    public class AuthenticationToken
    {
        public string AccessToken { get; private set; }
        public string RefreshToken { get; private set; }
        public int ExpiryLength { get; private set; }
        public DateTimeOffset Timestamp { get; private set; }

        public AuthenticationToken(string accessToken, string refreshToken, int expiryLength, DateTimeOffset timestamp)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            ExpiryLength = expiryLength;
            Timestamp = timestamp;
        }
    }
}
