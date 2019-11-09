using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Smallify.Module.Notifications.Configuration;
using Smallify.Module.Notifications.ViewModels;
using Smallify.Module.Notifications.Views;

namespace Smallify.Module.Notifications
{
    public class NotificationsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.Launch, typeof(NotificationsButtonView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register(typeof(NotificationsButtonView).ToString(), typeof(NotificationsButtonViewModel));
            ViewModelLocationProvider.Register(typeof(NotificationsShell).ToString(), typeof(NotificationsShellViewModel));
        }
    }
}
