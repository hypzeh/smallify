using Prism.Events;
using Smallify.Module.Core;
using Smallify.Module.Core.Events.Configuration;
using Smallify.Module.Core.Events.Notifications;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using System.Threading.Tasks;

namespace Smallify.Module.Player.Services
{
	public class SpotifyService : ISpotifyService
	{
		private readonly IEventAggregator _eventAggregator;
		private readonly IConfiguration _configuration;
		private readonly SpotifyWebAPI _spotify;

		public SpotifyService(
			IEventAggregator eventAggregator,
			IConfiguration configuration)
		{
			_eventAggregator = eventAggregator;
			_configuration = configuration;
			_spotify = new SpotifyWebAPI
			{
				UseAuth = true,
				TokenType = "Bearer",
				AccessToken = configuration.AccessToken
			};

			_eventAggregator.GetEvent<NewAccessTokenEvent>().Subscribe(NewAccessTokenRecieved);
		}

		public async Task PlayAsync()
		{
			var response = await _spotify.ResumePlaybackAsync(offset: string.Empty);
			if (response.HasError())
			{
				_eventAggregator.GetEvent<NewNotificationEvent>()?.Publish(response.Error.Message);
			}
		}

		public async Task PauseAsync()
		{
			var response = await _spotify.PausePlaybackAsync();
			if (response.HasError())
			{
				_eventAggregator.GetEvent<NewNotificationEvent>()?.Publish(response.Error.Message);
			}
		}

		public async Task SkipAsync()
		{
			var response = await _spotify.SkipPlaybackToNextAsync();
			if (response.HasError())
			{
				_eventAggregator.GetEvent<NewNotificationEvent>()?.Publish(response.Error.Message);
			}
		}

		public async Task PreviousAsync()
		{
			var response = await _spotify.SkipPlaybackToPreviousAsync();
			if (response.HasError())
			{
				_eventAggregator.GetEvent<NewNotificationEvent>()?.Publish(response.Error.Message);
			}
		}

		public async Task<FullTrack> GetPlaybackStateAsync()
		{
			var response = await _spotify.GetPlayingTrackAsync();
			if (response.HasError())
			{
				_eventAggregator.GetEvent<NewNotificationEvent>()?.Publish(response.Error.Message);
				return null;
			}

			return response.Item;
		}

		private void NewAccessTokenRecieved(string accessToken)
		{
			_spotify.AccessToken = accessToken;
		}
	}
}
