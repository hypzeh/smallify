using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Smallify.Module.Core;
using Smallify.Module.Core.Events.Configuration;
using System.Windows;
using System.Windows.Input;

namespace Smallify.GUI.ViewModels
{
	public class ShellViewModel : BindableBase, IShellViewModel
	{
		public ShellViewModel(
			IEventAggregator eventAggregator,
			IConfiguration configuration)
		{
			Configuration = configuration;

			ExitCommand = new DelegateCommand(() => Application.Current.Shutdown());
			MinimiseCommand = new DelegateCommand<Window>(window => window.WindowState = WindowState.Minimized);

			eventAggregator.GetEvent<OnConfigurationChangedEvent>()
				?.Subscribe(args => RaisePropertyChanged(nameof(Configuration)));
		}

		public ICommand ExitCommand { get; }

		public ICommand MinimiseCommand { get; }

		public IConfiguration Configuration { get; }
	}
}
