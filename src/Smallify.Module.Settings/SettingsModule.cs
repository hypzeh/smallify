﻿using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Smallify.Module.Settings.Constants;
using Smallify.Module.Settings.ViewModels;
using Smallify.Module.Settings.ViewModels.Sections;
using Smallify.Module.Settings.Views;
using Smallify.Module.Settings.Views.Sections;

namespace Smallify.Module.Settings
{
	public class SettingsModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionManager = containerProvider.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion(RegionNames.SETTINGS_BUTTON_REGION, typeof(SettingsButtonView));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<ISettingsButtonViewModel, SettingsButtonViewModel>();
			containerRegistry.Register<ISettingsShellViewModel, SettingsShellViewModel>();

			containerRegistry.Register<IAuthenticationViewModel, AuthenticationViewModel>();
			containerRegistry.Register<IGeneralViewModel, GeneralViewModel>();
			containerRegistry.Register<IAboutViewModel, AboutViewModel>();

			containerRegistry.RegisterForNavigation<Authentication>();
			containerRegistry.RegisterForNavigation<General>();
			containerRegistry.RegisterForNavigation<About>();
		}
	}
}
