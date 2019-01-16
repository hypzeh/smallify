using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Smallify.Module.Core.Events.Notifications;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsShellViewModel : BindableBase
	{
		public NotificationsShellViewModel(IEventAggregator eventAggregator)
		{
			ExitCommand = new DelegateCommand<Window>((window) => window.Close());

			Notifications = new ObservableCollection<string>()
			{
				"123",
				"456",
				"789"
			};


			eventAggregator.GetEvent<NewNotificationEvent>().Subscribe(NewNotificationReceived);
		}

		public ICommand ExitCommand { get; private set; }

		public ObservableCollection<string> Notifications { get; set; }

		private void NewNotificationReceived(string notification)
		{
			Notifications.Add(notification);
		}
	}
}
