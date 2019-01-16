using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Smallify.Module.Core.Events.Notifications;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsShellViewModel : BindableBase, INotificationsShellViewModel
	{
		public NotificationsShellViewModel(IEventAggregator eventAggregator)
		{
			Notifications = new ObservableCollection<string>();

			ExitCommand = new DelegateCommand<Window>((window) => window.Close());

			eventAggregator.GetEvent<NewNotificationEvent>().Subscribe(NewNotificationReceived);
		}

		public ICommand ExitCommand { get; private set; }

		public ObservableCollection<string> Notifications { get; set; }

		private void NewNotificationReceived(string notification)
		{
			Notifications.Add(notification);
		}
	}
}
