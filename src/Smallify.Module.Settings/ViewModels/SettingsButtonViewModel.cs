using Prism.Commands;
using Prism.Mvvm;
using Smallify.Module.Settings.Views;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
	public class SettingsButtonViewModel : BindableBase, ISettingsButtonViewModel
	{
		private readonly IShellViewModel _settingsShellViewModel;

		public SettingsButtonViewModel(IShellViewModel settingsShellViewModel)
		{
			_settingsShellViewModel = settingsShellViewModel;

			ShowSettingsWindowCommand = new DelegateCommand(ShowSettingsWindowCommand_Execute);
		}

		public ICommand ShowSettingsWindowCommand { get; }

		private void ShowSettingsWindowCommand_Execute()
		{
			var settingsShell = new Shell(_settingsShellViewModel);
			settingsShell.ShowDialog();
		}
	}
}
