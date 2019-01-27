using Prism.Regions;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
	public interface IShellViewModel
	{
		ICommand ExitCommand { get; }

		IRegionManager RegionManager { get; }
	}
}