using Prism.Regions;
using Smallify.Module.Notifications.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Smallify.Module.Notifications.Views
{
	public partial class NotificationsShell : Window
	{
		public NotificationsShell(
			IRegionManager regionManager,
			ObservableCollection<INotification> Notifications)
		{
			InitializeComponent();
		}
	}
}
