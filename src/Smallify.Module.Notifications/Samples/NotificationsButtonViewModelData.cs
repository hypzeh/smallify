using Smallify.Module.Notifications.Models;
using Smallify.Module.Notifications.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smallify.Module.Notifications.Samples
{
	public class NotificationsButtonViewModelData : INotificationsButtonViewModel
	{
		public ICommand ShowNotificationsWindowCommand => throw new NotImplementedException();

		public ObservableCollection<INotification> Notifications => new ObservableCollection<INotification>
		{
			new Notification("fake notification #1"),
			new Notification("fake notification #2"),
			new Notification("fake notification #3"),
			new Notification("fake notification #4"),
			new Notification("fake notification #5")
		};

		public bool IsButtonEnabled
		{
			get => true;
			set => throw new NotImplementedException();
		}
	}
}
