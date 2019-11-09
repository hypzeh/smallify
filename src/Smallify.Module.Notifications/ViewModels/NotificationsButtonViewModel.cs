using Prism.Commands;
using Prism.Mvvm;
using Smallify.Module.Notifications.Views;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
    internal class NotificationsButtonViewModel : BindableBase
    {
        private NotificationsShell _notificationsShell;

        public ICommand OpenNotificationsWindowCommand { get; }

        public NotificationsButtonViewModel()
        {
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
            _notificationsShell.Closed += (s, e) =>
            {
                _notificationsShell = null;
            };
            _notificationsShell.Show();
        }
    }
}
