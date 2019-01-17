using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsViewModel : BindableBase, INotificationsViewModel
	{
		public NotificationsViewModel(ObservableCollection<string> notifications)
		{
			Notifications = notifications;
		}

		public ObservableCollection<string> Notifications { get; }
	}
}
