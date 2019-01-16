using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Smallify.Module.Core.Constants;
using Smallify.Module.Notifications.ViewModels;
using Smallify.Module.Notifications.Views;

namespace Smallify.Module.Notifications
{
	public class NotificationsModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionManager = containerProvider.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion(RegionNames.NOTIFICATIONS_BUTTON_REGION, typeof(NotificationsButtonView));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<INotificationsButtonViewModel, NotificationsButtonViewModel>();
			containerRegistry.Register<INotificationsShellViewModel, NotificationsShellViewModel>();
		}
	}
}
