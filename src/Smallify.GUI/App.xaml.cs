﻿using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Smallify.GUI.ViewModels;
using Smallify.GUI.Views;
using Smallify.Module.Core;
using Smallify.Module.Notifications;
using Smallify.Module.Player;
using Smallify.Module.Settings;
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
			containerRegistry.Register<IConfiguration, Configuration>();

			containerRegistry.Register<IShellViewModel, ShellViewModel>();
		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<PlayerModule>();
			moduleCatalog.AddModule<SettingsModule>();
			moduleCatalog.AddModule<NotificationsModule>();
		}
	}
}
