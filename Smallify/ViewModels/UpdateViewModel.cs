using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Squirrel;
using System;
using System.Reflection;
using System.Windows.Input;

namespace Smallify.ViewModels
{
	public class UpdateViewModel : BindableBase
	{
		private UpdateManager _updateManager;
		private UpdateInfo _updateInfo;

		public UpdateViewModel(UpdateManager updateManager, UpdateInfo updateInfo)
		{
			this._updateManager = updateManager;
			this._updateInfo = updateInfo;

			this.AcceptUpdateCommand = new DelegateCommand(() => this.AcceptUpdateCommand_Execute());
			this.ExitUpdateCommand = new DelegateCommand(() => this.ExitUpdateCommand_Execute());
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
			using (this._updateManager)
			{
				this.ExitUpdateCommand_Execute();
				var release = await this._updateManager.UpdateApp();
				if (release != null)
				{
					this._updateManager.Dispose();
					UpdateManager.RestartApp();
				}
			}
		}

		private void ExitUpdateCommand_Execute()
		{
			this.CloseUpdateWindow?.Invoke();
		}
	}
}
