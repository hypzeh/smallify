using Prism.Mvvm;

namespace Smallify.Module.Settings.ViewModels
{
	public class AuthenticationViewModel : BindableBase
	{
		private string _accessToken;

		public AuthenticationViewModel()
		{
			_accessToken = string.Empty;
		}

		public string AccessToken
		{
			get => _accessToken;
			set => SetProperty(ref _accessToken, value);
		}
	}
}
