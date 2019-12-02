using Prism.Commands;
using Prism.Mvvm;
using Smallify.Core.Configuration;
using System.Windows;
using System.Windows.Input;

namespace Smallify.GUI.ViewModels
{
    internal class SmallifyShellViewModel : BindableBase
    {
        private string _title;

        public string Title
        {
            get => _title;
            private set => SetProperty(ref _title, value);
        }
        public GeneralSettings Settings { get; }
        public ICommand MinimiseCommand { get; }
        public ICommand ExitCommand { get; }

        public SmallifyShellViewModel(GeneralSettings settings)
        {
            _title = "Smallify";
            Settings = settings;
            MinimiseCommand = new DelegateCommand<Window>(MinimiseCommand_Execute);
            ExitCommand = new DelegateCommand(ExitCommand_Execute);

            Settings.PropertyChanged += (sender, args) => RaisePropertyChanged(nameof(Settings));
        }

        public void MinimiseCommand_Execute(Window window)
        {
            window.WindowState = WindowState.Minimized;
        }

        public void ExitCommand_Execute()
        {
            Application.Current.Shutdown();
        }
    }
}
