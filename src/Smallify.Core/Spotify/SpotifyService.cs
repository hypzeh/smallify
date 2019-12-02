using Smallify.Core.Configuration;
using Smallify.Core.Spotify.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Threading.Tasks;

namespace Smallify.Core.Spotify
{
    public class SpotifyService : ISpotifyService
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

        public async Task<ProfileResponse> GetCurrentUserAsync()
        {
            await RefreshTokenAsync();
            return Mapping.MapProfile(await _api.GetPrivateProfileAsync());
        }

        public async Task<PlaybackResponse> GetPlaybackAsync()
        {
            await RefreshTokenAsync();
            return Mapping.MapContext(await _api.GetPlaybackAsync());
        }

        public async Task<PlaybackResponse> ResumePlaybackAsync()
        {
            await RefreshTokenAsync();
            return await GetPlaybackWithActionAsync(_api.ResumePlaybackAsync(offset: string.Empty));
        }

        public async Task<PlaybackResponse> PausePlaybackAsync()
        {
            await RefreshTokenAsync();
            return await GetPlaybackWithActionAsync(_api.PausePlaybackAsync());
        }

        public async Task<PlaybackResponse> SkipPlaybackAsync()
        {
            await RefreshTokenAsync();
            return await GetPlaybackWithActionAsync(_api.SkipPlaybackToNextAsync());
        }

        public async Task<PlaybackResponse> PreviousPlaybackAsync()
        {
            await RefreshTokenAsync();
            return await GetPlaybackWithActionAsync(_api.SkipPlaybackToPreviousAsync());
        }

        public async Task<TokenResponse> ExchangeAccessCodeAsync(string code)
        {
            var token = await _authentication.ExchangeCode(code);
            UpdateToken(token);
            return Mapping.MapToken(token);
        }

        private async Task<PlaybackResponse> GetPlaybackWithActionAsync(Task<ErrorResponse> action)
        {
            var response = await action;
            if (response.HasError())
            {
                return new PlaybackResponse(response.Error.Message);
            }

            await Task.Delay(TimeSpan.FromSeconds(1d));
            return await GetPlaybackAsync();
        }

        private async Task RefreshTokenAsync()
        {
            if (!_settings.Token.HasExpired())
            {
                return;
            }

            UpdateToken(await _authentication.RefreshToken(_settings.Token.RefreshToken));
        }

        private void UpdateToken(Token token)
        {
            if (token.HasError())
            {
                _settings.ClearToken();
                return;
            }

            _api.AccessToken = token.AccessToken;
            _settings.SetToken(new AuthenticationToken(
                accessToken: token.AccessToken,
                refreshToken: token.RefreshToken ?? _settings.Token.RefreshToken,
                expiryLength: Convert.ToInt32(token.ExpiresIn),
                timestamp: token.CreateDate));
        }
    }
}
