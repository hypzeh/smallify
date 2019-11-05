using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Smallify.Module.Settings.Configuration;
using Smallify.Module.Settings.Views;

namespace Smallify.Module.Settings
{
    public class SettingsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.SettingsRegion, typeof(SettingsButtonView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
