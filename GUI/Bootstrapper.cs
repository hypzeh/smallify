using GUI.Shared.Interfaces;
using GUI.Shared.Utilities;
using GUI.Views;
using Microsoft.Practices.Unity;
using Player;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace GUI
{
	internal class Bootstrapper : UnityBootstrapper
	{
		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();

			this.Container.RegisterType<ICompositeCommandAggregator, CompositeCommandAggregator>(new ContainerControlledLifetimeManager());
		}

		protected override void ConfigureModuleCatalog()
		{
			var moduleCatalog = this.ModuleCatalog as ModuleCatalog;
			moduleCatalog.AddModule(typeof(PlayerModule));
		}

		protected override DependencyObject CreateShell()
		{
			return this.Container.Resolve<Shell>();
		}

		protected override void InitializeShell()
		{
			Application.Current.MainWindow.Show();
		}
	}
}