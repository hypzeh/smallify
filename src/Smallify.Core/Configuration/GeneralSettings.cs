using Jot;
using Jot.Configuration;
using System.ComponentModel;

namespace Smallify.Core.Configuration
{
    public class GeneralSettings : ITrackingAware<GeneralSettings>, INotifyPropertyChanged
    {
        public bool IsAlwaysOnTop { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public GeneralSettings()
        {
            IsAlwaysOnTop = false;

            new Tracker().Track(this);
        }

        public void SetIsAlwaysOnTop(bool isAlwaysOnTop)
        {
            IsAlwaysOnTop = isAlwaysOnTop;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAlwaysOnTop)));
        }

        public void ConfigureTracking(TrackingConfiguration<GeneralSettings> configuration)
        {
            configuration.Properties(settings => new { settings.IsAlwaysOnTop });
            PropertyChanged += (sender, args) => { configuration.Tracker.Persist(this); };
        }
    }
}
