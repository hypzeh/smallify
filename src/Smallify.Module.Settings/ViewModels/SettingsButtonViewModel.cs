using Prism.Commands;
using Prism.Mvvm;
using Smallify.Module.Settings.Views;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
    internal class SettingsButtonViewModel : BindableBase
    {
        private SettingsShell _settingsShell;

        public ICommand OpenSettingsWindowCommand { get; }

        public SettingsButtonViewModel()
        {
            OpenSettingsWindowCommand = new DelegateCommand(OpenSettingsWindowCommand_Execute);
        }

        private void OpenSettingsWindowCommand_Execute()
        {
            if (_settingsShell != null)
            {
                _settingsShell.Activate();
                return;
            }

            _settingsShell = new SettingsShell();
            _settingsShell.Closed += (sender, args) =>
            {
                _settingsShell = null;
            };
            _settingsShell.Show();
        }
    }
}
