using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Smallify.Module.Settings.Configuration;
using Smallify.Module.Settings.Views;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
    internal class SettingsShellViewModel : BindableBase
    {
        public IRegionManager RegionManager { get; }
        public ICommand SetSectionCommand { get; }
        public ICommand ExitCommand { get; }

        public SettingsShellViewModel(IRegionManager regionManager)
        {
            RegionManager = regionManager.CreateRegionManager();
            SetSectionCommand = new DelegateCommand<string>(SetSectionCommand_Execute);
            ExitCommand = new DelegateCommand<Window>(ExitCommand_Execute);

            RegionManager.RegisterViewWithRegion(RegionNames.Section, typeof(GeneralSectionView));
        }

        private void SetSectionCommand_Execute(string section)
        {
            RegionManager.RequestNavigate(RegionNames.Section, section);
        }

        public void ExitCommand_Execute(Window window)
        {
            window.Close();
        }
    }
}
