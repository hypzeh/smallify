using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Updater.ViewModels;
using Updater.Views;

namespace Updater
{
	[Module(ModuleName = "Updater")]
	public class UpdaterModule : IModule
	{
		private IUnityContainer _container;
		private IRegionManager _regionManager;

		public UpdaterModule(IUnityContainer container, IRegionManager regionManager)
		{
			this._container = container;
			this._regionManager = regionManager;
		}

		public void Initialize()
		{
			this.RegisterViewModels();
			this.RegisterViews();
		}

		public void RegisterViewModels()
		{
			this._container.RegisterType<ViewAViewModel>();
		}

		public void RegisterViews()
		{
			this._container.RegisterType<ViewA>();
		}
	}
}