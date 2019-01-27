using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
	public class ShellViewModel : BindableBase, IShellViewModel
	{
		public ShellViewModel(IRegionManager regionManager)
		{
			RegionManager = regionManager;

			ExitCommand = new DelegateCommand<Window>(window => window.Close());
		}

		public ICommand ExitCommand { get; }

		public IRegionManager RegionManager { get; }
	}
}
