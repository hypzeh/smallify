using System.Windows;

namespace Smallify.Module.Notifications.Views
{
	public partial class NotificationsShell : Window
	{
		public NotificationsShell()
		{
			InitializeComponent();

			ShowInTaskbar = false;
		}
	}
}
