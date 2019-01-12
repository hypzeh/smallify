using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace Smallify.Module.Player.ViewModels
{
	public class PlayerViewModel : BindableBase
	{

		public PlayerViewModel()
		{
			PreviousCommand = new DelegateCommand(PreviousCommand_Execute);
			PlayCommand = new DelegateCommand(PlayCommand_Execute);
			PauseCommand = new DelegateCommand(PauseCommand_Execute);
			SkipCommand = new DelegateCommand(SkipCommand_Execute);
		}

		public ICommand PreviousCommand { get; private set; }

		public ICommand PlayCommand { get; private set; }

		public ICommand PauseCommand { get; private set; }

		public ICommand SkipCommand { get; private set; }

		private void PreviousCommand_Execute()
		{
			throw new NotImplementedException();
		}

		private void PlayCommand_Execute()
		{
			throw new NotImplementedException();
		}

		private void PauseCommand_Execute()
		{
			throw new NotImplementedException();
		}

		private void SkipCommand_Execute()
		{
			throw new NotImplementedException();
		}
	}
}
