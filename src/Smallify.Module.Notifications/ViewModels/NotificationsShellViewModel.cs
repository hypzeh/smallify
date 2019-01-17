using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsShellViewModel : BindableBase, INotificationsShellViewModel
	{
		public NotificationsShellViewModel(ObservableCollection<string> notifications)
		{
			ExitCommand = new DelegateCommand<Window>((window) => window.Close());

			NotificationsViewModel = new NotificationsViewModel(notifications);
		}

		public ICommand ExitCommand { get; private set; }

		public INotificationsViewModel NotificationsViewModel { get; }
	}
}
