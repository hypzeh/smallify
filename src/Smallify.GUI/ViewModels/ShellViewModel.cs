using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;

namespace Smallify.GUI.ViewModels
{
	public class ShellViewModel : BindableBase
	{
		public ShellViewModel()
		{
			ExitCommand = new DelegateCommand(() => Application.Current.Shutdown());
			MinimiseCommand = new DelegateCommand<Window>(window => window.WindowState = WindowState.Minimized);
		}

		public ICommand ExitCommand { get; private set; }

		public ICommand MinimiseCommand { get; private set; }
	}
}
