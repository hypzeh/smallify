using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
	public interface ISettingsViewModel
	{
		ICommand SaveCommand { get; }

		string AccessToken { get; set; }
	}
}