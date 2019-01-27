using Smallify.Module.Settings.ViewModels;
using System.Windows;

namespace Smallify.Module.Settings.Views
{
	public partial class Shell : Window
	{
		public Shell(ISettingsShellViewModel settingsShellViewModel)
		{
			InitializeComponent();
			DataContext = settingsShellViewModel;
		}
	}
}
