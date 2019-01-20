using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
	public class SettingsShellViewModel : BindableBase
	{
		public SettingsShellViewModel()
		{
			ExitCommand = new DelegateCommand<Window>(window => window.Close());
		}

		public ICommand ExitCommand { get; }
	}
}
