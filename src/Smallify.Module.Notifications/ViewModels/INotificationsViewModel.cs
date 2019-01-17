using Smallify.Module.Notifications.Models;
using System.Collections.ObjectModel;

namespace Smallify.Module.Notifications.ViewModels
{
	public interface INotificationsViewModel
	{
		ObservableCollection<INotification> Notifications { get; }
	}
}