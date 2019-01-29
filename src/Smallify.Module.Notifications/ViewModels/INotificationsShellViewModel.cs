using Prism.Regions;
using Smallify.Module.Notifications.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public interface INotificationsShellViewModel
	{
		ICommand ExitCommand { get; }

		IRegionManager RegionManager { get; }

		ObservableCollection<INotification> Notifications { get; }
	}
}