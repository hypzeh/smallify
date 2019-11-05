using Prism.Mvvm;
using Smallify.GUI.Properties;

namespace Smallify.GUI.ViewModels
{
    internal class SmallifyShellViewModel : BindableBase
    {
        private string _title;
        private string _testingText;

        public string Title
        {
            get => _title;
            private set => SetProperty(ref _title, value);
        }

        public string TestingText
        {
            get => _testingText;
            private set => SetProperty(ref _testingText, value);
        }

        public SmallifyShellViewModel()
        {
            _title = "Smallify";
            _testingText = $"app_center_id: {Resources.APP_CENTER_CLIENT_ID}\nspotify_id: {Resources.SPOTIFY_CLIENT_ID}\nspotify_secret: {Resources.SPOTIFY_CLIENT_SECRET}";
        }
    }
}
