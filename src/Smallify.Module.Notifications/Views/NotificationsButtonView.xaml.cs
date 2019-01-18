using Smallify.Module.Notifications.ViewModels;
using System.Windows.Controls;

namespace Smallify.Module.Notifications.Views
{
	public partial class NotificationsButtonView : UserControl
	{
		public NotificationsButtonView(INotificationsButtonViewModel notificationsButtonViewModel)
		{
			InitializeComponent();
			DataContext = notificationsButtonViewModel;
		}
	}
}
