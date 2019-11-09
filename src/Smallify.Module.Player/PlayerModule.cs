using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Smallify.Module.Player.Configuration;
using Smallify.Module.Player.Views;

namespace Smallify.Module.Player
{
    public class PlayerModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.Content, typeof(PlayerView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
