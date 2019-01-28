using Prism.Mvvm;
using Smallify.Module.Core;

namespace Smallify.Module.Settings.ViewModels
{
	public class AuthenticationViewModel : BindableBase
	{
		private readonly IConfiguration _configuration;

		private string _accessToken;

		public AuthenticationViewModel(IConfiguration configuration)
		{
			_configuration = configuration;

			_accessToken = configuration.AccessToken;
		}

		public string AccessToken
		{
			get => _accessToken;
			set => SetProperty(ref _accessToken, value);
		}
	}
}
