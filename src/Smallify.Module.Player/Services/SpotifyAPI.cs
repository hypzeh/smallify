using Smallify.Module.Core;
using SpotifyAPI.Web;
using System.ComponentModel;

namespace Smallify.Module.Player.Services
{
	public class SpotifyAPI
	{
		private readonly IConfiguration _configuration;
		private readonly SpotifyWebAPI _spotify;

		public SpotifyAPI(IConfiguration configuration)
		{
			_configuration = configuration;
			_spotify = new SpotifyWebAPI
			{
				UseAuth = true,
				TokenType = "Bearer",
				AccessToken = configuration.AccessToken
			};

			_configuration.PropertyChanged += Configuration_PropertyChanged;
		}

		private void Configuration_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(IConfiguration.AccessToken))
			{
				_spotify.AccessToken = _configuration.AccessToken;
			}
		}
	}
}
