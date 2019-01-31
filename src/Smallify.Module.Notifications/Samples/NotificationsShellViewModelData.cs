using Prism.Regions;
using Smallify.Module.Notifications.Models;
using Smallify.Module.Notifications.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smallify.Module.Notifications.Samples
{
	public class NotificationsShellViewModelData : INotificationsShellViewModel
	{
		public ICommand ExitCommand { get; }

		public ICommand DismissNotificationCommand { get; }

		public ICommand ClearNotificationsCommand { get; }

		public IRegionManager RegionManager { get; }

		public ObservableCollection<INotification> Notifications => new ObservableCollection<INotification>
		{
			new Notification("This is a long notification message to test the design of long notifications and how they wrap."),
			new Notification("fake notification #1"),
			new Notification("fake notification #2"),
			new Notification("fake notification #3"),
			new Notification("fake notification #4"),
			new Notification("fake notification #5")
		};
	}
}
