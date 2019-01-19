using Prism.Events;
using Smallify.Module.Core;
using Smallify.Module.Core.Events.Configuration;
using SpotifyAPI.Web;

namespace Smallify.Module.Player.Services
{
	public class SpotifyService
	{
		private readonly IConfiguration _configuration;
		private readonly SpotifyWebAPI _spotify;

		public SpotifyService(IConfiguration configuration, IEventAggregator eventAggregator)
		{
			_configuration = configuration;
			_spotify = new SpotifyWebAPI
			{
				UseAuth = true,
				TokenType = "Bearer",
				AccessToken = configuration.AccessToken
			};

			eventAggregator.GetEvent<NewAccessTokenEvent>().Subscribe(NewAccessTokenRecieved);
		}

		private void NewAccessTokenRecieved(string accessToken)
		{
			_spotify.AccessToken = accessToken;
		}
	}
}
