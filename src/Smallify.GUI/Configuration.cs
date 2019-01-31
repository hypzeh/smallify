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

		public Configuration(IEventAggregator eventAggregator)
		{
			_eventAggregator = eventAggregator;


			var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
			Verion = $"v{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Build}-beta";
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
					_eventAggregator.GetEvent<OnConfigurationChangedEvent>()
						?.Publish(new ConfigurationChangedEventArgs(nameof(AccessToken), Settings.Default.AccessToken));
				}
			}
		}

		public string Verion { get; }

		public bool AlwaysOnTop
		{
			get => Settings.Default.AlwaysOnTop;
			set
			{
				if (value != Settings.Default.AlwaysOnTop)
				{
					Settings.Default.AlwaysOnTop = value;
					Settings.Default.Save();
					_eventAggregator.GetEvent<OnConfigurationChangedEvent>()
						?.Publish(new ConfigurationChangedEventArgs(nameof(AlwaysOnTop), Settings.Default.AlwaysOnTop));
				}
			}
		}
	}
}
