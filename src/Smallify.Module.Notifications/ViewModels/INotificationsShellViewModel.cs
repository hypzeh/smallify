using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public interface INotificationsShellViewModel
	{
		ICommand ExitCommand { get; }

		INotificationsViewModel NotificationsViewModel { get; }
	}
}