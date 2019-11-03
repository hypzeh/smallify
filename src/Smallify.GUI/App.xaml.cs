using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using Smallify.GUI.ViewModels;
using Smallify.GUI.Views;
using System.Windows;

namespace Smallify.GUI
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<SmallifyShell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register(typeof(SmallifyShell).ToString(), typeof(SmallifyShellViewModel));
        }
    }
}
