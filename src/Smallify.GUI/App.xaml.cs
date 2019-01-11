using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Smallify.GUI.Views;
using System.Windows;

namespace Smallify.GUI
{
	public partial class App : PrismApplication
	{
		protected override Window CreateShell()
		{
			return Container.Resolve<Shell>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{

		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<Module.Player.Module>();
		}
	}
}
