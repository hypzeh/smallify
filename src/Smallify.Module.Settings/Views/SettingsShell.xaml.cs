using Prism.Regions;
using Smallify.Module.Settings.ViewModels;
using System.Windows;

namespace Smallify.Module.Settings.Views
{
	public partial class SettingsShell : Window
	{
		public SettingsShell(IRegionManager regionManager)
		{
			InitializeComponent();
			DataContext = new SettingsShellViewModel(regionManager);
		}
	}
}
