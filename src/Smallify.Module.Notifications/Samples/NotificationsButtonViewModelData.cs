using Smallify.Module.Notifications.ViewModels;
using System;
using System.Windows.Input;

namespace Smallify.Module.Notifications.Samples
{
	public class NotificationsButtonViewModelData : INotificationsButtonViewModel
	{
		public ICommand ShowNotificationsWindowCommand => throw new NotImplementedException();

		public bool IsButtonEnabled
		{
			get => true;
			set => throw new NotImplementedException();
		}
	}
}
