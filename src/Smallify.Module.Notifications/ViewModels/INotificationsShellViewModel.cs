using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public interface INotificationsShellViewModel
	{
		ICommand ExitCommand { get; }

		ObservableCollection<string> Notifications { get; set; }
	}
}