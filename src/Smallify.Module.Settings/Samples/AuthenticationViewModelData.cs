using Smallify.Module.Settings.ViewModels;
using System.Windows.Input;

namespace Smallify.Module.Settings.Samples
{
	public class AuthenticationViewModelData : IAuthenticationViewModel
	{
		public string AccessToken
		{
			get => "access token goes here...";
			set => throw new System.NotImplementedException();
		}

		public ICommand GetAccessTokenCommand { get; }

		public ICommand PasteAccessTokenCommand { get; }
	}
}
