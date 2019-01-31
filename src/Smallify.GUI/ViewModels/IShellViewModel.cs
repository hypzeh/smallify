using Smallify.Module.Core;
using System.Windows.Input;

namespace Smallify.GUI.ViewModels
{
	public interface IShellViewModel
	{
		ICommand ExitCommand { get; }

		ICommand MinimiseCommand { get; }

		IConfiguration Configuration { get; }
	}
}