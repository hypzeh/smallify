using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsShellViewModel : BindableBase
	{
		public NotificationsShellViewModel()
		{
			ExitCommand = new DelegateCommand<Window>((window) => window.Close());
		}

		public ICommand ExitCommand { get; private set; }
	}
}
