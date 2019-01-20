using Smallify.Module.Settings.ViewModels;
using System.Windows;

namespace Smallify.Module.Settings.Views
{
	public partial class SettingsShell : Window
	{
		public SettingsShell()
		{
			InitializeComponent();
			DataContext = new SettingsShellViewModel();
		}
	}
}
