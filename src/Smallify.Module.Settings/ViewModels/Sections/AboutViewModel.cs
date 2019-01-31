using Prism.Commands;
using Prism.Mvvm;
using Smallify.Module.Core;
using System.Diagnostics;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels.Sections
{
	public class AboutViewModel : BindableBase, IAboutViewModel
	{
		public AboutViewModel(IConfiguration configuration)
		{
			Version = configuration.Verion;

			OpenGithubCommand = new DelegateCommand(OpenGithubCommand_Execute);
		}

		public ICommand OpenGithubCommand { get; }

		public string Version { get; }

		private void OpenGithubCommand_Execute()
		{
			Process.Start("https://github.com/hypzeh/smallify");
		}
	}
}
