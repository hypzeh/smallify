using Smallify.GUI.Properties;
using Smallify.Module.Core;

namespace Smallify.GUI
{
	public class Configuration : IConfiguration
	{
		public string ClientID => Settings.Default.ClientID;
	}
}
