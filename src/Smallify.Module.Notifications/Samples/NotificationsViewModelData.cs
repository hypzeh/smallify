using Smallify.Module.Notifications.ViewModels;
using System.Collections.ObjectModel;

namespace Smallify.Module.Notifications.Samples
{
	public class NotificationsViewModelData : INotificationsViewModel
	{
		public ObservableCollection<string> Notifications => new ObservableCollection<string>
		{
			"fake notification #1",
			"fake notification #2",
			"fake notification #3",
			"fake notification #4",
			"fake notification #5"
		};
	}
}
