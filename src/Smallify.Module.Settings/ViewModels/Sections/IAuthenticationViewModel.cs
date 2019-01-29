using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels.Sections
{
	public interface IAuthenticationViewModel
	{
		string AccessToken { get; set; }

		ICommand GetAccessTokenCommand { get; }

		ICommand PasteAccessTokenCommand { get; }
	}
}