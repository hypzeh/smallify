using Smallify.Module.Notifications.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Smallify.Module.Notifications.Samples
{
	public class NotificationsButtonViewModelData : INotificationsButtonViewModel
	{
		public ICommand ShowNotificationsWindowCommand => throw new NotImplementedException();

		public ObservableCollection<string> Notifications => new ObservableCollection<string>
		{
			"fake notification #1",
			"fake notification #2",
			"fake notification #3",
			"fake notification #4",
			"fake notification #5"
		};

		public bool IsButtonEnabled
		{
			get => true;
			set => throw new NotImplementedException();
		}
	}
}
