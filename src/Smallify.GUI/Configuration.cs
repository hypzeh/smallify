using Prism.Events;
using Smallify.GUI.Properties;
using Smallify.Module.Core;
using Smallify.Module.Core.Events.Configuration;
using System.Reflection;

namespace Smallify.GUI
{
	public class Configuration : IConfiguration
	{
		private readonly IEventAggregator _eventAggregator;
		private readonly string _version;

		public Configuration(IEventAggregator eventAggregator)
		{
			_eventAggregator = eventAggregator;

			var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
			_version = $"v{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Build}-beta";
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

		public string Verion => _version;
	}
}
