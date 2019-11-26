using Prism.Mvvm;
using Smallify.Core.Configuration;
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
            set
            {
                SetProperty(ref _isAlwaysOnTop, value);
                _settings.SetIsAlwaysOnTop(value);
            }
        }

        public GeneralSectionViewModel(GeneralSettings settings)
        {
            _settings = settings;
            _isAlwaysOnTop = settings?.IsAlwaysOnTop ?? throw new ArgumentNullException(nameof(settings));
        }
    }
}
