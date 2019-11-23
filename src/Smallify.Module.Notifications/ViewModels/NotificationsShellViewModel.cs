using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Smallify.Module.Notifications.Configuration;
using Smallify.Module.Notifications.Views;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
    internal class NotificationsShellViewModel : BindableBase
    {
        public IRegionManager RegionManager { get; }
        public ICommand ExitCommand { get; }

        public NotificationsShellViewModel(IRegionManager regionManager)
        {
            RegionManager = regionManager.CreateRegionManager();
            ExitCommand = new DelegateCommand<Window>(ExitCommand_Execute);

            RegionManager.RegisterViewWithRegion(RegionNames.Content, typeof(NotificationsContentView));
        }

        public void ExitCommand_Execute(Window window)
        {
            window.Close();
        }
    }
}
