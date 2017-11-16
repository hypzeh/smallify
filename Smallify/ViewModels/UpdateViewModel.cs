using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Smallify.Interfaces;
using Smallify.Models;
using Smallify.Windows;
using Squirrel;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smallify.ViewModels
{
	public class UpdateViewModel : BindableBase
	{
		private readonly DelegateCommand _acceptUpdateCommand;
		private readonly DelegateCommand _exitUpdateCommand;
		private readonly DelegateCommand _whatsNewCommand;

		private string _updateVersion;

		public UpdateViewModel()
		{
			// Package Manager Console> Squirrel --releasify smallify.1.0.0.nupkg --setupIcon D:\Development\Projects\Smallify\Smallify\Resources\Icon\Smallify_Default.ico --no-msi

			UpdaterModel.Setup();
			this.UpdateCheck().ContinueWith(x => FoundUpdates(x.Result));

			this._acceptUpdateCommand = new DelegateCommand(() => this.AcceptUpdateCommand_Execute());
			this._exitUpdateCommand = new DelegateCommand(() => this.ExitUpdateCommand_Execute());
			this._whatsNewCommand = new DelegateCommand(() => this.WhatsNewCommand_Execute());
		}

		public event Action CloseUpdateWindow;

		public event Action ShowUpdateWindow;

		public ICommand AcceptUpdateCommand
		{
			get
			{
				return this._acceptUpdateCommand;
			}
		}

		public ICommand ExitUpdateCommand
		{
			get
			{
				return this._exitUpdateCommand;
			}
		}

		public ICommand WhatsNewCommand
		{
			get
			{
				return this._whatsNewCommand;
			}
		}

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
				return this._updateVersion;
			}

			set
			{
				this.SetProperty<string>(ref this._updateVersion, value);
				this.OnPropertyChanged(nameof(this.NewVersion));
			}
		}

		private async Task<bool> UpdateCheck()
		{
			var updateCheck = await UpdaterModel.CheckForUpdate();
			if (updateCheck)
			{
				this.NewVersion = await UpdaterModel.GetUpdateVersion();
				return true;
			}

			return false;
		}

		private void FoundUpdates(bool foundUpdates)
		{
			if (foundUpdates)
			{
				this.ShowUpdateWindow?.Invoke();
			}
		}

		private void AcceptUpdateCommand_Execute()
		{
			this.ExitUpdateCommand_Execute();
			UpdaterModel.ApplyUpdate();
		}

		private void ExitUpdateCommand_Execute()
		{
			this.CloseUpdateWindow?.Invoke();
		}

		private void WhatsNewCommand_Execute()
		{
			Process.Start(@"https://github.com/Hypzeh/Smallify/releases/latest");
		}
	}
}
