using Prism.Events;
using Prism.Mvvm;
using Smallify.Core.Configuration;
using Smallify.Core.Events.Settings;
using System;

namespace Smallify.Module.Settings.ViewModels
{
    public class GeneralSectionViewModel : BindableBase
    {
        private readonly GeneralSettings _settings;
        private bool _isAlwaysOnTop;

        public bool IsAlwaysOnTop
        {
            get => _isAlwaysOnTop;
            set => SetProperty(ref _isAlwaysOnTop, value);
        }

        public GeneralSectionViewModel(IEventAggregator eventAggregator, GeneralSettings settings)
        {
            _settings = settings;
            _isAlwaysOnTop = settings?.IsAlwaysOnTop ?? throw new ArgumentNullException(nameof(settings));

            var saveEvent = eventAggregator?.GetEvent<OnSettingsSaveEvent>() ?? throw new ArgumentNullException(nameof(eventAggregator));
            saveEvent?.Subscribe(OnSettingsSave);
        }

        private void OnSettingsSave()
        {
            if (_settings.IsAlwaysOnTop != _isAlwaysOnTop)
            {
                _settings.SetIsAlwaysOnTop(_isAlwaysOnTop);
            }
        }
    }
}
