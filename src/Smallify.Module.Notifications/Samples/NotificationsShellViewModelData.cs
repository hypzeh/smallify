using Prism.Regions;
using Smallify.Module.Notifications.Models;
using Smallify.Module.Notifications.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smallify.Module.Notifications.Samples
{
	public class NotificationsShellViewModelData : INotificationsShellViewModel
	{
		public ICommand ExitCommand { get; }

		public IRegionManager RegionManager { get; }

		public ObservableCollection<INotification> Notifications { get; }
	}
}
