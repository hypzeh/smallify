using Prism.Commands;
using Prism.Mvvm;
using Smallify.Module.Notifications.Services;
using Smallify.Module.Notifications.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
    internal class NotificationsButtonViewModel : BindableBase
    {
        private NotificationsShell _notificationsShell;

        public ObservableCollection<string> Notifications { get; }
        public ICommand OpenNotificationsWindowCommand { get; }

        public NotificationsButtonViewModel(NotificationCollectionService notificationCollectionService)
        {
            Notifications = notificationCollectionService.Notifications;

            OpenNotificationsWindowCommand = new DelegateCommand(OpenNotificationsWindowCommand_Execute);
        }

        private void OpenNotificationsWindowCommand_Execute()
        {
            if (_notificationsShell != null)
            {
                _notificationsShell.Activate();
                return;
            }

            _notificationsShell = new NotificationsShell();
            _notificationsShell.Closed += (sender, args) =>
            {
                _notificationsShell = null;
            };
            _notificationsShell.Show();
        }
    }
}
