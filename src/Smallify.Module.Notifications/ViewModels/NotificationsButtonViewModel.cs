using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Smallify.Module.Core.Events.Notifications;
using Smallify.Module.Notifications.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsButtonViewModel : BindableBase, INotificationsButtonViewModel
	{
		private bool _isButtonEnabled;

		public NotificationsButtonViewModel(IEventAggregator eventAggregator)
		{
			_isButtonEnabled = true;

			Notifications = new ObservableCollection<string>();

			ShowNotificationsWindowCommand = new DelegateCommand(ShowNotificationsWindowCommand_Execute);

			eventAggregator.GetEvent<NewNotificationEvent>().Subscribe(NewNotificationReceived);
		}

		public ICommand ShowNotificationsWindowCommand { get; }

		public ObservableCollection<string> Notifications { get; }

		public bool IsButtonEnabled
		{
			get => _isButtonEnabled;
			set => SetProperty(ref _isButtonEnabled, value);
		}

		private void ShowNotificationsWindowCommand_Execute()
		{
			var shell = new NotificationsShell(new NotificationsShellViewModel(Notifications));
			shell.Show();
		}

		private void NewNotificationReceived(string notification)
		{
			Notifications.Add(notification);
		}
	}
}
