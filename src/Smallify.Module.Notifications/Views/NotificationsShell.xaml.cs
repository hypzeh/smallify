using Prism.Regions;
using Smallify.Module.Notifications.Models;
using Smallify.Module.Notifications.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace Smallify.Module.Notifications.Views
{
	public partial class NotificationsShell : Window
	{
		public NotificationsShell(
			IRegionManager regionManager,
			ObservableCollection<INotification> notifications)
		{
			InitializeComponent();
			DataContext = new NotificationsShellViewModel(regionManager, notifications);
		}
	}
}
