using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsShellViewModel : BindableBase
	{
		public NotificationsShellViewModel()
		{
			ExitCommand = new DelegateCommand<Window>((window) => window.Close());
			AddNotificationCommand = new DelegateCommand(() => Notifications.Add("some notification..."));

			Notifications = new ObservableCollection<string>()
			{
				"123",
				"456",
				"789"
			};
		}

		public ICommand ExitCommand { get; private set; }

		public ICommand AddNotificationCommand { get; private set; }

		public ObservableCollection<string> Notifications { get; set; }
	}
}
