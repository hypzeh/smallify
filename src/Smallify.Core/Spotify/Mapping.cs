using Smallify.Core.Spotify.Models;
using SpotifyAPI.Web.Models;
using System.Linq;

namespace Smallify.Core.Spotify
{
    internal static class Mapping
    {
        internal static PlaybackResponse MapContext(this PlaybackContext context)
        {
            if (context == null)
            {
                return new PlaybackResponse("Could not reach Spotify services");
            }

            if (context.HasError())
            {
                return new PlaybackResponse(context.Error.Message);
            }

            if (context.Item == null)
            {
                return new PlaybackResponse("Could not find a playable device/track");
            }

            return new PlaybackResponse(
                isPlaying: context.IsPlaying,
                progress: context.ProgressMs,
                track: new Track(
                    name: context.Item.Name,
                    artist: string.Join(", ", context.Item.Artists.Select(artist => artist.Name)),
                    album: context.Item.Album.Name,
                    albumArt: context.Item.Album.Images.FirstOrDefault()?.Url,
                    duration: context.Item.DurationMs));
        }

        internal static ProfileResponse MapProfile(PrivateProfile profile)
        {
            if (profile == null)
            {
                return new ProfileResponse("Could not reach Spotify services");
            }

            if (profile.HasError())
            {
                return new ProfileResponse(profile.Error.Message);
            }

            return new ProfileResponse(
                displayName: profile.DisplayName,
                username: profile.Id);
        }

        internal static TokenResponse MapToken(Token token)
        {
            if (token == null)
            {
                return new TokenResponse("Could not reach Spotify service");
            }

            if (token.HasError())
            {
                return new TokenResponse(token.ErrorDescription);
            }

            return new TokenResponse(
                accessToken: token.AccessToken,
                refreshToken: token.RefreshToken);
        }
    }
}
