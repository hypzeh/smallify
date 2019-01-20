using Smallify.Module.Settings.ViewModels;
using System.Windows.Input;

namespace Smallify.Module.Settings.Samples
{
	public class SettingsViewModelData : ISettingsViewModel
	{
		public ICommand SaveCommand { get; }

		public string AccessToken
		{
			get => "some bearer access token";
			set => throw new System.NotImplementedException();
		}
	}
}
