using Prism.Mvvm;
using Smallify.Module.Notifications.Services;
using System.Collections.ObjectModel;

namespace Smallify.Module.Notifications.ViewModels
{
    internal class NotificationsContentViewModel : BindableBase
    {
        public ObservableCollection<string> Notifications { get; }

        public NotificationsContentViewModel(NotificationCollectionService notificationCollectionService)
        {
            Notifications = notificationCollectionService.Notifications;
        }
    }
}
