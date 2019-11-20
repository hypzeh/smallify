using Smallify.Core.Configuration;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Threading.Tasks;

namespace Smallify.Core.Spotify
{
    public class SpotifyService
    {
        private readonly AuthenticationSettings _settings;
        private readonly AuthorizationCodeAuth _authentication;
        private readonly SpotifyWebAPI _api;

        public SpotifyService(AuthenticationSettings settings)
        {
            _settings = settings;
            _authentication = new AuthorizationCodeAuth(
                clientId: _settings.ClientID,
                secretId: _settings.ClientSecret,
                redirectUri: _settings.RedirectURI,
                serverUri: _settings.RedirectURI,
                scope: Scope.UserReadPrivate
                    | Scope.UserReadCurrentlyPlaying
                    | Scope.UserReadPlaybackState
                    | Scope.UserModifyPlaybackState);
            _api = new SpotifyWebAPI
            {
                AccessToken = _settings.Token.AccessToken,
                TokenType = "Bearer",
                UseAuth = true,
            };
        }

        public void OpenBrowser()
        {
            _authentication.OpenBrowser();
        }

        public async Task<PrivateProfile> GetCurrentUserAsync()
        {
            if (_settings.Token.HasExpired())
            {
                await RefreshTokenAsync();
            }

            return await _api.GetPrivateProfileAsync(); ;
        }

        private async Task RefreshTokenAsync()
        {
            if (string.IsNullOrEmpty(_settings.Token.RefreshToken))
            {
                await ExchangeCodeAsync();
                return;
            }

            AssignToken(
                await _authentication.RefreshToken(_settings.Token.RefreshToken),
                () => _settings.SetToken(new AuthenticationToken(string.Empty, string.Empty, 0, DateTimeOffset.UtcNow)));
        }

        private async Task ExchangeCodeAsync()
        {
            if (string.IsNullOrEmpty(_settings.AuthorisationCode))
            {
                return;
            }

            AssignToken(
                await _authentication.ExchangeCode(_settings.AuthorisationCode),
                () => _settings.SetAuthorisationCode(string.Empty));
        }

        private void AssignToken(Token token, Action onError)
        {
            if (token.HasError())
            {
                onError();
                return;
            }

            _api.AccessToken = token.AccessToken;
            _settings.SetToken(new AuthenticationToken(
                accessToken: token.AccessToken,
                refreshToken: token.RefreshToken,
                expiryLength: Convert.ToInt32(token.ExpiresIn),
                timestamp: token.CreateDate));
        }
    }
}
