using Prism.Commands;
using Prism.Mvvm;
using Smallify.Core.Configuration;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
    public class GeneralSectionViewModel : BindableBase
    {

        public ICommand SaveSettingsCommand { get; }

        public GeneralSectionViewModel(SmallifySettings settings)
        {
            SaveSettingsCommand = new DelegateCommand(SaveSettingsCommand_Execute);
        }

        private void SaveSettingsCommand_Execute()
        {

        }
    }
}
