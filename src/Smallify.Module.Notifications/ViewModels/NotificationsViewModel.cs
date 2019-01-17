using Prism.Mvvm;
using Smallify.Module.Notifications.Models;
using System.Collections.ObjectModel;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsViewModel : BindableBase, INotificationsViewModel
	{
		public NotificationsViewModel(ObservableCollection<INotification> notifications)
		{
			Notifications = notifications;
		}

		public ObservableCollection<INotification> Notifications { get; }
	}
}
