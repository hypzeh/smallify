using Prism.Commands;
using Prism.Mvvm;
using Smallify.Module.Notifications.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsViewModel : BindableBase, INotificationsViewModel
	{
		public NotificationsViewModel(ObservableCollection<INotification> notifications)
		{
			Notifications = notifications;

			DismissNotificationCommand = new DelegateCommand<INotification>(DismissNotificationCommand_Execute);
			ClearNotificationsCommand = new DelegateCommand(ClearNotificationsCommand_Execute);
		}

		public ICommand DismissNotificationCommand { get; }

		public ICommand ClearNotificationsCommand { get; }

		public ObservableCollection<INotification> Notifications { get; }

		private void DismissNotificationCommand_Execute(INotification notification)
		{
			Notifications.Remove(notification);
		}

		private void ClearNotificationsCommand_Execute()
		{
			Notifications.Clear();
		}
	}
}
