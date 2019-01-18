using Smallify.Module.Notifications.ViewModels;
using System.Windows.Input;

namespace Smallify.Module.Notifications.Samples
{
	public class NotificationsShellViewModelData : INotificationsShellViewModel
	{
		public ICommand ExitCommand { get; }

		public INotificationsViewModel NotificationsViewModel => new NotificationsViewModelData();
	}
}
