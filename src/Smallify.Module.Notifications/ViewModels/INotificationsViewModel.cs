using System.Collections.ObjectModel;

namespace Smallify.Module.Notifications.ViewModels
{
	public interface INotificationsViewModel
	{
		ObservableCollection<string> Notifications { get; }
	}
}