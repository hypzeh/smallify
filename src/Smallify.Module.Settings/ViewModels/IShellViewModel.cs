using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
	public interface ISettingsShellViewModel
	{
		ICommand ExitCommand { get; }
	}
}