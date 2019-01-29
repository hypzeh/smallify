using Prism.Regions;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public interface INotificationsShellViewModel
	{
		ICommand ExitCommand { get; }

		IRegionManager RegionManager { get; }
	}
}