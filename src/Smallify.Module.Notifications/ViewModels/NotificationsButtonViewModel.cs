using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Smallify.Module.Core.Events.Notifications;
using Smallify.Module.Notifications.Models;
using Smallify.Module.Notifications.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsButtonViewModel : BindableBase, INotificationsButtonViewModel
	{
		private readonly IRegionManager _regionManager;

		private NotificationsShell _notificationsShell;

		public NotificationsButtonViewModel(
			IEventAggregator eventAggregator,
			IRegionManager regionManager)
		{
			_regionManager = regionManager;

			Notifications = new ObservableCollection<INotification>();

			ShowNotificationsWindowCommand = new DelegateCommand(ShowNotificationsWindowCommand_Execute);

			eventAggregator.GetEvent<OnNotificationCreatedEvent>()
				?.Subscribe(message => Notifications.Add(new Notification(message)));
		}

		public ICommand ShowNotificationsWindowCommand { get; }

		public ObservableCollection<INotification> Notifications { get; }

		private void ShowNotificationsWindowCommand_Execute()
		{
			if (_notificationsShell != null)
			{
				return;
			}

			_notificationsShell = new NotificationsShell(_regionManager.CreateRegionManager(), Notifications);
			_notificationsShell.Closed += (s, e) =>
			{
				_notificationsShell = null;
			};
			_notificationsShell.Show();
		}
	}
}
