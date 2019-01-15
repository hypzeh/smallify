using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsButtonViewModel : BindableBase
	{
		private bool _isButtonEnabled;

		public NotificationsButtonViewModel()
		{
			_isButtonEnabled = true;

			ShowNotificationsWindowCommand = new DelegateCommand(ShowNotificationsWindowCommand_Execute);
		}

		public ICommand ShowNotificationsWindowCommand { get; private set; }

		public bool IsButtonEnabled
		{
			get => _isButtonEnabled;
			set => SetProperty(ref _isButtonEnabled, value);
		}

		private void ShowNotificationsWindowCommand_Execute()
		{
			throw new NotImplementedException();
		}
	}
}
