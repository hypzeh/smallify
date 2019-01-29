using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Smallify.Module.Core.Events.Notifications;
using Smallify.Module.Notifications.Models;
using Smallify.Module.Notifications.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsButtonViewModel : BindableBase, INotificationsButtonViewModel
	{
		public NotificationsButtonViewModel(IEventAggregator eventAggregator)
		{
			Notifications = new ObservableCollection<INotification>();

			ShowNotificationsWindowCommand = new DelegateCommand(ShowNotificationsWindowCommand_Execute);

			eventAggregator.GetEvent<OnNotificationCreatedEvent>().Subscribe(NewNotificationReceived);
		}

		public ICommand ShowNotificationsWindowCommand { get; }

		public ObservableCollection<INotification> Notifications { get; }

		private void ShowNotificationsWindowCommand_Execute()
		{
			var shell = new NotificationsShell(new NotificationsShellViewModel(Notifications));
			shell.ShowDialog();
		}

		private void NewNotificationReceived(string message)
		{
			Notifications.Add(new Notification(message));
		}
	}
}
