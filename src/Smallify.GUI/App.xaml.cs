using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
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
            containerRegistry
                .RegisterInstance(new GeneralSettings())
                .RegisterInstance(new AuthenticationSettings(
                    GUI.Properties.Resources.SPOTIFY_CLIENT_ID,
                    GUI.Properties.Resources.SPOTIFY_CLIENT_SECRET));
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

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppCenter.Start(
                GUI.Properties.Resources.APP_CENTER_CLIENT_ID,
                typeof(Analytics),
                typeof(Crashes));
        }
    }
}
