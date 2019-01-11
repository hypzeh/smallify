using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Smallify.Module.Core.Constants;
using Smallify.Module.Player.Views;

namespace Smallify.Module.Player
{
	public class Module : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionManager = containerProvider.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion(RegionNames.PLAYER_REGION, typeof(PlayerView));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{

		}
	}
}
