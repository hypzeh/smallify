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

			_eventAggregator.GetEvent<OnConfigurationChangedEvent>()
				?.Subscribe(OnConfigurationChangedEvent_Published);
		}

		public async Task<bool> TryPlayAsync()
		{
			var response = await _spotify.ResumePlaybackAsync(offset: string.Empty);
			if (response.HasError())
			{
				_eventAggregator.GetEvent<OnNotificationCreatedEvent>()?.Publish(response.Error.Message);
				return false;
			}

			return true;
		}

		public async Task<bool> TryPauseAsync()
		{
			var response = await _spotify.PausePlaybackAsync();
			if (response.HasError())
			{
				_eventAggregator.GetEvent<OnNotificationCreatedEvent>()?.Publish(response.Error.Message);
				return false;
			}

			return true;
		}

		public async Task<bool> TrySkipAsync()
		{
			var response = await _spotify.SkipPlaybackToNextAsync();
			if (response.HasError())
			{
				_eventAggregator.GetEvent<OnNotificationCreatedEvent>()?.Publish(response.Error.Message);
				return false;
			}

			return true;
		}

		public async Task<bool> TryPreviousAsync()
		{
			var response = await _spotify.SkipPlaybackToPreviousAsync();
			if (response.HasError())
			{
				_eventAggregator.GetEvent<OnNotificationCreatedEvent>()?.Publish(response.Error.Message);
				return false;
			}

			return true;
		}

		public async Task<PlaybackContext> GetPlaybackStateAsync()
		{
			var response = await _spotify.GetPlayingTrackAsync();
			if (response.HasError())
			{
				_eventAggregator.GetEvent<OnNotificationCreatedEvent>()?.Publish(response.Error.Message);
				return null;
			}

			return response;
		}

		private void OnConfigurationChangedEvent_Published(ConfigurationChangedEventArgs configuration)
		{
			if (nameof(IConfiguration.AccessToken) != configuration.Name)
			{
				return;
			}

			_spotify.AccessToken = _configuration.AccessToken;
		}
	}
}
