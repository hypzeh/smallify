using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using Smallify.Core.Configuration;
using Smallify.GUI.ViewModels;
using Smallify.GUI.Views;
using Smallify.Module.Settings;
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
            containerRegistry.RegisterSingleton<SmallifySettings>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register(typeof(SmallifyShell).ToString(), typeof(SmallifyShellViewModel));
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<SettingsModule>();
        }
    }
}
