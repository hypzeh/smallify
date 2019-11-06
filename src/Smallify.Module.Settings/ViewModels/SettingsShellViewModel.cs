using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Smallify.Module.Settings.Configuration;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
    internal class SettingsShellViewModel : BindableBase
    {
        public IRegionManager RegionManager { get; }

        public ICommand SetSectionCommand { get; }

        public SettingsShellViewModel(IRegionManager regionManager)
        {
            RegionManager = regionManager;
            SetSectionCommand = new DelegateCommand<string>(SetSectionCommand_Execute);
        }

        private void SetSectionCommand_Execute(string section)
        {
            RegionManager.RequestNavigate(RegionNames.Section, section);
        }
    }
}
