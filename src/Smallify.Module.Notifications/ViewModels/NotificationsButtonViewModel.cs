using Prism.Commands;
using Prism.Mvvm;
using Smallify.Module.Notifications.Views;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsButtonViewModel : BindableBase, INotificationsButtonViewModel
	{
		private readonly INotificationsShellViewModel _notificationsShellViewModel;

		private bool _isButtonEnabled;

		public NotificationsButtonViewModel(INotificationsShellViewModel notificationsShellViewModel)
		{
			_notificationsShellViewModel = notificationsShellViewModel;
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
			var shell = new NotificationsShell(_notificationsShellViewModel);
			shell.ShowDialog();
		}
	}
}
