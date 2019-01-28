using Prism.Commands;
using Prism.Mvvm;
using Smallify.Module.Core;
using System.Windows;
using System.Windows.Input;

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

			GetAccessTokenCommand = new DelegateCommand(GetAccessTokenCommand_Execute);
			PasteAccessTokenCommand = new DelegateCommand(PasteAccessTokenCommand_Execute);
		}

		public ICommand GetAccessTokenCommand { get; }

		public ICommand PasteAccessTokenCommand { get; }

		public string AccessToken
		{
			get => _accessToken;
			set => SetProperty(ref _accessToken, value);
		}

		private void GetAccessTokenCommand_Execute()
		{
			System.Diagnostics.Process.Start("https://smallify.nicksmirnoff.co.uk/");
		}

		private void PasteAccessTokenCommand_Execute()
		{
			if (!Clipboard.ContainsText())
			{
				return;
			}

			AccessToken = Clipboard.GetText();
		}
	}
}
