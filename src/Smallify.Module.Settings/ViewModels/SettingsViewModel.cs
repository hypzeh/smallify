using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
	public class SettingsViewModel : BindableBase, ISettingsViewModel
	{
		public SettingsViewModel()
		{
			SaveCommand = new DelegateCommand(SaveCommand_Execute);
		}

		public ICommand SaveCommand { get; }

		private void SaveCommand_Execute()
		{
			throw new NotImplementedException();
		}
	}
}
