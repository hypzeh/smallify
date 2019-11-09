namespace Smallify.Core.Configuration
{
    public class GeneralSettings
    {
        public bool IsAlwaysOnTop { get; private set; }

        public GeneralSettings()
        {
            IsAlwaysOnTop = true;
        }

        public void SetIsAlwaysOnTop(bool isAlwaysOnTop)
        {
            IsAlwaysOnTop = isAlwaysOnTop;
        }
    }
}
