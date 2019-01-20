using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Smallify.Module.Core.Constants;
using Smallify.Module.Settings.Views;

namespace Smallify.Module.Settings
{
	public class SettingsModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionManager = containerProvider.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion(RegionNames.SETTINGS_BUTTON_REGION, typeof(SettingsButtonView));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{

		}
	}
}
