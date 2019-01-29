using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Smallify.Module.Settings.Constants;
using Smallify.Module.Settings.Views.Sections;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
	public class SettingsShellViewModel : BindableBase, ISettingsShellViewModel
	{
		public SettingsShellViewModel(IRegionManager regionManager)
		{
			RegionManager = regionManager;

			ExitCommand = new DelegateCommand<Window>(window => window.Close());
			SwitchSettingsSection = new DelegateCommand<string>(SwitchSettingsSection_Execute);

			RegionManager.RegisterViewWithRegion(RegionNames.SECTION_CONTENT_REGION, typeof(Authentication));
		}

		public ICommand ExitCommand { get; }

		public ICommand SwitchSettingsSection { get; }

		public IRegionManager RegionManager { get; }

		private void SwitchSettingsSection_Execute(string sectionName)
		{
			RegionManager.RequestNavigate(RegionNames.SECTION_CONTENT_REGION, sectionName);
		}
	}
}
