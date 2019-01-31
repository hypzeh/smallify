using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Smallify.Module.Settings.Views;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
	public class SettingsButtonViewModel : BindableBase, ISettingsButtonViewModel
	{
		private readonly IRegionManager _regionManager;

		private SettingsShell _settingsShell;

		public SettingsButtonViewModel(IRegionManager regionManager)
		{
			_regionManager = regionManager;

			ShowSettingsWindowCommand = new DelegateCommand(ShowSettingsWindowCommand_Execute);
		}

		public ICommand ShowSettingsWindowCommand { get; }

		private void ShowSettingsWindowCommand_Execute()
		{
			if (_settingsShell != null)
			{
				return;
			}

			_settingsShell = new SettingsShell(_regionManager.CreateRegionManager());
			_settingsShell.Closed += (s, e) =>
			{
				_settingsShell = null;
			};
			_settingsShell.Show();
		}
	}
}
