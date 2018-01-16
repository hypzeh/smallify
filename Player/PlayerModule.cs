using Player.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Player.ViewModels;
using Player.Models;

namespace Player
{
	[Module(ModuleName = "Player")]
	public class PlayerModule : IModule
	{
		private IRegionManager _regionManager;
		private IUnityContainer _container;

		public PlayerModule(IUnityContainer container, IRegionManager regionManager)
		{
			this._container = container;
			this._regionManager = regionManager;
		}

		public void Initialize()
		{
			this.RegisterModels();
			this.RegisterViewModels();
			this.RegisterViews();
		}

		public void RegisterModels()
		{
			this._container.RegisterType<PlayerModel>();
		}

		public void RegisterViewModels()
		{
			this._container.RegisterType<ViewAViewModel>();
		}

		public void RegisterViews()
		{
			this._container.RegisterTypeForNavigation<ViewA>();

			// Region register
			this._regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
		}
	}
}