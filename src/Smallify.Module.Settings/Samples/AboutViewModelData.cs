using Smallify.Module.Settings.ViewModels;
using System.Windows.Input;

namespace Smallify.Module.Settings.Samples
{
	public class AboutViewModelData : IAboutViewModel
	{
		public ICommand OpenGithubCommand { get; }

		public string Version => "v0.0.0-alpha";
	}
}
