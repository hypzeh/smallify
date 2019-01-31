using Prism.Regions;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
	public interface ISettingsShellViewModel
	{
		ICommand ExitCommand { get; }

		ICommand SwitchSettingsSection { get; }

		IRegionManager RegionManager { get; }
	}
}