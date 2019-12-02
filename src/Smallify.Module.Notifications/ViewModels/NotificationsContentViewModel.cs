using Prism.Commands;
using Prism.Mvvm;
using Smallify.Module.Notifications.Models;
using Smallify.Module.Notifications.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
    internal class NotificationsContentViewModel : BindableBase
    {
        public ObservableCollection<Notification> Notifications { get; }
        public ICommand DismissNotificationCommand { get; }
        public ICommand DismissAllNotificationsCommand { get; }

        public NotificationsContentViewModel(NotificationCollectionService notificationCollectionService)
        {
            Notifications = notificationCollectionService.Notifications;
            DismissNotificationCommand = new DelegateCommand<Notification>(DismissNotificationCommand_Execute);
            DismissAllNotificationsCommand = new DelegateCommand(DismissAllNotificationsCommand_Execute);
        }

        private void DismissNotificationCommand_Execute(Notification notification)
        {
            Notifications.Remove(notification);
        }

        private void DismissAllNotificationsCommand_Execute()
        {
            Notifications.Clear();
        }
    }
}
