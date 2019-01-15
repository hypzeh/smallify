using Prism.Mvvm;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsButtonViewModel : BindableBase
	{
		private bool _isButtonEnabled;

		public NotificationsButtonViewModel()
		{
			_isButtonEnabled = true;
		}

		public bool IsButtonEnabled
		{
			get => _isButtonEnabled;
			set => SetProperty(ref _isButtonEnabled, value);
		}
	}
}
