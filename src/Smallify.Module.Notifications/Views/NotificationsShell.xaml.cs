using Smallify.Module.Notifications.ViewModels;
using System.Windows;

namespace Smallify.Module.Notifications.Views
{
	public partial class NotificationsShell : Window
	{
		public NotificationsShell(NotificationsShellViewModel notificationsShellViewModel)
		{
			InitializeComponent();
			DataContext = notificationsShellViewModel;
		}
	}
}
