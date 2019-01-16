using Prism.Events;
using Prism.Mvvm;
using Smallify.Module.Core.Events.Notifications;
using System.Collections.ObjectModel;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsViewModel : BindableBase, INotificationsViewModel
	{
		public NotificationsViewModel(IEventAggregator eventAggregator)
		{
			eventAggregator.GetEvent<NewNotificationEvent>().Subscribe(NewNotificationReceived);

			Notifications = new ObservableCollection<string>();
		}

		public ObservableCollection<string> Notifications { get; set; }

		private void NewNotificationReceived(string notification)
		{
			Notifications.Add(notification);
		}
	}
}
