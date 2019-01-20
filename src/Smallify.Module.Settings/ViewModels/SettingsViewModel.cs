using Prism.Commands;
using Prism.Mvvm;
using Smallify.Module.Core;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
	public class SettingsViewModel : BindableBase, ISettingsViewModel
	{
		private readonly IConfiguration _configuration;

		private string _accessToken;

		public SettingsViewModel(IConfiguration configuration)
		{
			_configuration = configuration;

			_accessToken = configuration.AccessToken;

			SaveCommand = new DelegateCommand(SaveCommand_Execute);
		}

		public ICommand SaveCommand { get; }

		public string AccessToken
		{
			get => _accessToken;
			set => SetProperty(ref _accessToken, value);
		}

		private void SaveCommand_Execute()
		{
			_configuration.AccessToken = AccessToken;
		}
	}
}
