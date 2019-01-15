using Smallify.Module.Notifications.ViewModels;
using System.Windows.Controls;

namespace Smallify.Module.Notifications.Views
{
	public partial class NotificationsButtonView : UserControl
	{
		public NotificationsButtonView()
		{
			InitializeComponent();
			DataContext = new NotificationsButtonViewModel();
		}
	}
}
