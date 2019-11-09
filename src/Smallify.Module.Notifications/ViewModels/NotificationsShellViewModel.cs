using Prism.Mvvm;
using Prism.Regions;
using Smallify.Module.Notifications.Configuration;
using Smallify.Module.Notifications.Views;

namespace Smallify.Module.Notifications.ViewModels
{
    internal class NotificationsShellViewModel : BindableBase
    {
        public IRegionManager RegionManager { get; }

        public NotificationsShellViewModel(IRegionManager regionManager)
        {
            RegionManager = regionManager.CreateRegionManager();

            RegionManager.RegisterViewWithRegion(RegionNames.Content, typeof(NotificationsContentView));
        }
    }
}
