using System.ComponentModel;

namespace Smallify.Core.Configuration
{
    public class GeneralSettings : INotifyPropertyChanged
    {
        public bool IsAlwaysOnTop { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public GeneralSettings()
        {
            IsAlwaysOnTop = true;
        }

        public void SetIsAlwaysOnTop(bool isAlwaysOnTop)
        {
            IsAlwaysOnTop = isAlwaysOnTop;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAlwaysOnTop)));
        }
    }
}
