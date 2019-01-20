using Smallify.Module.Settings.ViewModels;
using System.Windows;

namespace Smallify.Module.Settings.Views
{
	public partial class SettingsShell : Window
	{
		public SettingsShell(ISettingsShellViewModel settingsShellViewModel)
		{
			InitializeComponent();
			DataContext = settingsShellViewModel;
		}
	}
}
