using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public interface INotificationsButtonViewModel
	{
		ICommand ShowNotificationsWindowCommand { get; }

		ObservableCollection<string> Notifications { get; }

		bool IsButtonEnabled { get; set; }
	}
}