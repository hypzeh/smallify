using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
	public class SettingsShellViewModel : BindableBase, ISettingsShellViewModel
	{
		public SettingsShellViewModel(ISettingsViewModel settingsViewModel)
		{
			SettingsViewModel = settingsViewModel;

			ExitCommand = new DelegateCommand<Window>(window => window.Close());
		}

		public ICommand ExitCommand { get; }

		public ISettingsViewModel SettingsViewModel { get; }
	}
}
