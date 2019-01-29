using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels.Sections
{
	public interface IAboutViewModel
	{
		ICommand OpenGithubCommand { get; }

		string Version { get; }
	}
}