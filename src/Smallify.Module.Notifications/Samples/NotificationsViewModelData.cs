using Smallify.Module.Notifications.ViewModels;
using System.Collections.ObjectModel;

namespace Smallify.Module.Notifications.Samples
{
	public class NotificationsViewModelData : INotificationsViewModel
	{
		public ObservableCollection<string> Notifications
		{
			get => new ObservableCollection<string>()
			{
				"Fake Notification #1",
				"Fake Notitication #2",
				"Fake Notitication #3",
				"Fake Notitication #4",
				"Fake Notitication #5"
			};
			set => throw new System.NotImplementedException();
		}
	}
}
