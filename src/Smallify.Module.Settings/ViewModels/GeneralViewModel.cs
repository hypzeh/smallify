using Prism.Mvvm;
using Smallify.Module.Core;

namespace Smallify.Module.Settings.ViewModels
{
	public class GeneralViewModel : BindableBase, IGeneralViewModel
	{
		private readonly IConfiguration _configuration;

		private bool _alwaysOnTopEnabled;

		public GeneralViewModel(IConfiguration configuration)
		{
			_configuration = configuration;

			_alwaysOnTopEnabled = configuration.AlwaysOnTop;
		}

		public bool AlwaysOnTopEnabled
		{
			get => _alwaysOnTopEnabled;
			set
			{
				if (SetProperty(ref _alwaysOnTopEnabled, value))
				{
					_configuration.AlwaysOnTop = value;
				}
			}
		}
	}
}
