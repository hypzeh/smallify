using Smallify.Core.Spotify.Models;
using System.Threading.Tasks;

namespace Smallify.Core.Spotify
{
    public interface ISpotifyService
    {
        Task<TokenResponse> ExchangeAccessCodeAsync(string code);
        Task<ProfileResponse> GetCurrentUserAsync();
        Task<PlaybackResponse> GetPlaybackAsync();
        void OpenBrowser();
        Task<PlaybackResponse> PausePlaybackAsync();
        Task<PlaybackResponse> PreviousPlaybackAsync();
        Task<PlaybackResponse> ResumePlaybackAsync();
        Task<PlaybackResponse> SkipPlaybackAsync();
    }
}