using Smallify.GUI.ViewModels;
using Smallify.Module.Core;
using System.Windows.Input;

namespace Smallify.GUI.Samples
{
	public class ShellViewModelData : IShellViewModel
	{
		public ICommand ExitCommand { get; }

		public ICommand MinimiseCommand { get; }

		public IConfiguration Configuration { get; }
	}
}
