using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
	public interface IAuthenticationViewModel
	{
		string AccessToken { get; set; }

		ICommand GetAccessTokenCommand { get; }

		ICommand PasteAccessTokenCommand { get; }
	}
}