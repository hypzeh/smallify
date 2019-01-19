using System.Threading.Tasks;

namespace Smallify.Module.Player.Services
{
	public interface ISpotifyService
	{
		Task PlayAsync();

		Task PauseAsync();

		Task SkipAsync();

		Task PreviousAsync();
	}
}