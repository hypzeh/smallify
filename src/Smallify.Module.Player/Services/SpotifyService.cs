using Smallify.Module.Core;
using SpotifyAPI.Web;

namespace Smallify.Module.Player.Services
{
	public class SpotifyService
	{
		private readonly IConfiguration _configuration;
		private readonly SpotifyWebAPI _spotify;

		public SpotifyService(IConfiguration configuration)
		{
			_configuration = configuration;
			_spotify = new SpotifyWebAPI
			{
				UseAuth = true,
				TokenType = "Bearer",
				AccessToken = configuration.AccessToken
			};
		}
	}
}
