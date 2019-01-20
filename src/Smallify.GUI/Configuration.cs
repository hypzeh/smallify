using Prism.Events;
using Smallify.GUI.Properties;
using Smallify.Module.Core;
using Smallify.Module.Core.Events.Configuration;

namespace Smallify.GUI
{
	public class Configuration : IConfiguration
	{
		private readonly IEventAggregator _eventAggregator;

		public Configuration(IEventAggregator eventAggregator)
		{
			_eventAggregator = eventAggregator;
		}

		public string ClientID => Settings.Default.ClientID;

		public string AccessToken
		{
			get => Settings.Default.AccessToken;
			set
			{
				if (value != Settings.Default.AccessToken)
				{
					Settings.Default.AccessToken = value;
					Settings.Default.Save();
					_eventAggregator.GetEvent<NewAccessTokenEvent>()?.Publish(value);
				}
			}
		}
	}
}
