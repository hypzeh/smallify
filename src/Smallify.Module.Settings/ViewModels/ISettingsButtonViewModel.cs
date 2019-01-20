using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
	public interface ISettingsButtonViewModel
	{
		ICommand ShowSettingsWindowCommand { get; }
	}
}