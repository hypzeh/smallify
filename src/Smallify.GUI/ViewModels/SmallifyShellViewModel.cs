using Prism.Mvvm;
using Smallify.Core.Configuration;

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


        public SmallifyShellViewModel(GeneralSettings settings)
        {
            _title = "Smallify";

            Settings = settings;
            Settings.PropertyChanged += (sender, args) => RaisePropertyChanged(nameof(Settings));
        }
    }
}
