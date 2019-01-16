using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsShellViewModel : BindableBase, INotificationsShellViewModel
	{
		public NotificationsShellViewModel(INotificationsViewModel notificationsViewModel)
		{
			ExitCommand = new DelegateCommand<Window>((window) => window.Close());

			NotificationsViewModel = notificationsViewModel;
		}

		public ICommand ExitCommand { get; private set; }

		public INotificationsViewModel NotificationsViewModel { get; private set; }
	}
}
