using Smallify.GUI.Properties;
using Smallify.Module.Core;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Smallify.GUI
{
	public class Configuration : IConfiguration
	{
		public event PropertyChangedEventHandler PropertyChanged;

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
					NotifyPropertyChanged();
				}
			}
		}

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
