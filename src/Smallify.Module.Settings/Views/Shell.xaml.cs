﻿using Prism.Regions;
using Smallify.Module.Settings.ViewModels;
using System.Windows;

namespace Smallify.Module.Settings.Views
{
	public partial class Shell : Window
	{
		public Shell(IRegionManager regionManager)
		{
			InitializeComponent();
			DataContext = new ShellViewModel(regionManager);
		}
	}
}
