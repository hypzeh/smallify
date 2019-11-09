using Prism.Mvvm;

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


        public SmallifyShellViewModel()
        {
            _title = "Smallify";
        }
    }
}
