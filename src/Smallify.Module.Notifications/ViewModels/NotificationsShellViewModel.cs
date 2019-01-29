﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Smallify.Module.Notifications.Models;
using Smallify.Module.Notifications.Views.Sections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Module.Notifications.ViewModels
{
	public class NotificationsShellViewModel : BindableBase, INotificationsShellViewModel
	{
		public NotificationsShellViewModel(
			IRegionManager regionManager,
			ObservableCollection<INotification> notifications)
		{
			RegionManager = regionManager;
			Notifications = notifications;

			ExitCommand = new DelegateCommand<Window>(window => window.Close());

			RegionManager.RegisterViewWithRegion("", typeof(NotificationsView));
		}

		public ICommand ExitCommand { get; }

		public IRegionManager RegionManager { get; }

		public ObservableCollection<INotification> Notifications { get; }
	}
}
