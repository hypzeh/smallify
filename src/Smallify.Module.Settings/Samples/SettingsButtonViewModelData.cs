using Smallify.Module.Settings.ViewModels;
using System.Windows.Input;

namespace Smallify.Module.Settings.Samples
{
	public class SettingsButtonViewModelData : ISettingsButtonViewModel
	{
		public ICommand ShowSettingsWindowCommand { get; }
	}
}
