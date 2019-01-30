using SpotifyAPI.Web.Models;
using System.Threading.Tasks;

namespace Smallify.Module.Player.Services
{
	public interface ISpotifyService
	{
		Task<bool> TryPlayAsync();

		Task<bool> TryPauseAsync();

		Task<bool> TrySkipAsync();

		Task<bool> TryPreviousAsync();

		Task<PlaybackContext> GetPlaybackStateAsync();
	}
}