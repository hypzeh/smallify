using Prism.Commands;
using Prism.Mvvm;
using Smallify.Module.Notifications.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsShellViewModel : BindableBase, INotificationsShellViewModel
	{
		public NotificationsShellViewModel(ObservableCollection<INotification> notifications)
		{
			ExitCommand = new DelegateCommand<Window>(window => window.Close());

			NotificationsViewModel = new NotificationsViewModel(notifications);
		}

		public ICommand ExitCommand { get; }

		public INotificationsViewModel NotificationsViewModel { get; }
	}
}
