using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
    internal class NotificationsButtonViewModel : BindableBase
    {
        public ICommand OpenNotificationsWindowCommand { get; }

        public NotificationsButtonViewModel()
        {
            OpenNotificationsWindowCommand = new DelegateCommand(OpenNotificationsWindowCommand_Execute);
        }

        private void OpenNotificationsWindowCommand_Execute()
        {

        }
    }
}
