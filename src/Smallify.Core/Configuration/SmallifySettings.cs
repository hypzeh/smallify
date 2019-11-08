namespace Smallify.Core.Configuration
{
    public class SmallifySettings
    {
        public GeneralSettings General { get; }

        public SmallifySettings()
        {
            General = new GeneralSettings();
        }
    }
}
