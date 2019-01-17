using Smallify.Module.Notifications.Models;
using Smallify.Module.Notifications.ViewModels;
using System.Collections.ObjectModel;

namespace Smallify.Module.Notifications.Samples
{
	public class NotificationsViewModelData : INotificationsViewModel
	{
		public ObservableCollection<INotification> Notifications => new ObservableCollection<INotification>
		{
			new Notification("fake notification #1"),
			new Notification("fake notification #2"),
			new Notification("fake notification #3"),
			new Notification("fake notification #4"),
			new Notification("fake notification #5")
		};
	}
}
