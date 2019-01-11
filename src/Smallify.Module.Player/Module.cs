using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Smallify.Module.Player.Views;

namespace Smallify.Module.Player
{
	public class Module : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionManager = containerProvider.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion("MainContentRegion", typeof(PlayerView));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{

		}
	}
}
