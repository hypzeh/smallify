using Smallify.Module.Settings.ViewModels;
using System.Windows.Input;

namespace Smallify.Module.Settings.Samples
{
	public class ShellViewModelData : IShellViewModel
	{
		public ICommand ExitCommand { get; }
	}
}
