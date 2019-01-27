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

		public SettingsButtonViewModel(IRegionManager regionManager)
		{
			_regionManager = regionManager;

			ShowSettingsWindowCommand = new DelegateCommand(ShowSettingsWindowCommand_Execute);
		}

		public ICommand ShowSettingsWindowCommand { get; }

		private void ShowSettingsWindowCommand_Execute()
		{
			var shell = new Shell(_regionManager.CreateRegionManager());
			shell.Show();
		}
	}
}
