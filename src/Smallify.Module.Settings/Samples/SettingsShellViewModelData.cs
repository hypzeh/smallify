using Smallify.Module.Settings.ViewModels;
using System.Windows.Input;

namespace Smallify.Module.Settings.Samples
{
	public class SettingsShellViewModelData : ISettingsShellViewModel
	{
		public ICommand ExitCommand { get; }

		public ISettingsViewModel SettingsViewModel => new SettingsViewModelData();
	}
}
