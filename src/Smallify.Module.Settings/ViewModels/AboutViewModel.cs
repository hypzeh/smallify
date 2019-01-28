using Prism.Commands;
using Prism.Mvvm;
using System.Diagnostics;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
	public class AboutViewModel : BindableBase
	{
		public AboutViewModel()
		{
			OpenGithubCommand = new DelegateCommand(OpenGithubCommand_Execute);
		}

		public ICommand OpenGithubCommand { get; }

		private void OpenGithubCommand_Execute()
		{
			Process.Start("https://github.com/hypzeh/smallify");
		}
	}
}
