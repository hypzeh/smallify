using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Smallify.Core.Events.Settings;
using Smallify.Module.Settings.Configuration;
using Smallify.Module.Settings.Views;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
    internal class SettingsShellViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public IRegionManager RegionManager { get; }
        public ICommand SetSectionCommand { get; }
        public ICommand SaveSettingsCommand { get; }

        public SettingsShellViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _eventAggregator = eventAggregator;

            RegionManager = regionManager.CreateRegionManager();
            SetSectionCommand = new DelegateCommand<string>(SetSectionCommand_Execute);
            SaveSettingsCommand = new DelegateCommand(SaveSettingsCommand_Execute);

            RegionManager.RegisterViewWithRegion(RegionNames.Section, typeof(GeneralSectionView));
        }

        private void SetSectionCommand_Execute(string section)
        {
            RegionManager.RequestNavigate(RegionNames.Section, section);
        }

        private void SaveSettingsCommand_Execute()
        {
            _eventAggregator.GetEvent<OnSettingsSaveEvent>()?.Publish();
        }
    }
}
