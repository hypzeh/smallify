using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public interface INotificationsButtonViewModel
	{
		ICommand ShowNotificationsWindowCommand { get; }

		bool IsButtonEnabled { get; set; }
	}
}