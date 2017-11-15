using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Smallify.Windows;
using Squirrel;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

namespace Smallify.ViewModels
{
	public class UpdateViewModel : BindableBase
	{
		private UpdateManager _updateManager;
		private UpdateInfo _updateInfo;

		public UpdateViewModel()
		{
			// Package Manager Console> Squirrel --releasify smallify.1.0.0.nupkg --setupIcon D:\Development\Projects\Smallify\Smallify\Resources\Icon\Smallify_Default.ico --no-msi
			// Check for Squirrel application update
			//this._updateManager = UpdateManager.GitHubUpdateManager("https://github.com/Hypzeh/Smallify").Result;
			//this._updateInfo = null;

			//SquirrelAwareApp.HandleEvents(
			//	onInitialInstall: v => this._updateManager.CreateShortcutForThisExe(),
			//	onAppUpdate: v => this._updateManager.CreateShortcutForThisExe(),
			//	onAppUninstall: v => this._updateManager.RemoveShortcutForThisExe());

			//this.UpdateCheck();

			//this.AcceptUpdateCommand = new DelegateCommand(() => this.AcceptUpdateCommand_Execute());
			//this.ExitUpdateCommand = new DelegateCommand(() => this.ExitUpdateCommand_Execute());
		}

		public ICommand AcceptUpdateCommand { get; private set; }

		public ICommand ExitUpdateCommand { get; private set; }

		public string Version
		{
			get
			{
				return string.Format("{0}.{1}.{2}",
					Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(),
					Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString(),
					Assembly.GetExecutingAssembly().GetName().Version.Build.ToString());
			}
		}

		public string NewVersion
		{
			get
			{
				return this._updateInfo.FutureReleaseEntry.Version.ToString();
			}
		}

		public event Action CloseUpdateWindow;

		private async void AcceptUpdateCommand_Execute()
		{
			//using (this._updateManager)
			//{
			//	this.ExitUpdateCommand_Execute();
			//	var release = await this._updateManager.UpdateApp();
			//	if (release != null)
			//	{
			//		this._updateManager.Dispose();
			//		UpdateManager.RestartApp();
			//	}
			//}
		}

		private void ExitUpdateCommand_Execute()
		{
			this.CloseUpdateWindow?.Invoke();
		}

		//private async void UpdateCheck()
		//{
		//	// Check for updates
		//	this._updateInfo = await this._updateManager.CheckForUpdate(true, x => Console.WriteLine(x));

		//	// IF Updates found open update window
		//	if (this._updateInfo.ReleasesToApply.Any())
		//	{
		//		var updateWindow = new UpdateWindow(this, this._updateManager, this._updateInfo);
		//		updateWindow.Show();
		//		updateWindow.Activate();
		//	}
		//}
	}
}
