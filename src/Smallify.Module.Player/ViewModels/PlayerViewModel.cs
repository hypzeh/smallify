using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace Smallify.Module.Player.ViewModels
{
    internal class PlayerViewModel : BindableBase
    {
        public ICommand PlayCommand { get; }
        public ICommand PauseCommand { get; }
        public ICommand SkipCommand { get; }
        public ICommand PreviousCommand { get; }

        public PlayerViewModel()
        {
            PlayCommand = new DelegateCommand(PlayCommand_Execute);
            PauseCommand = new DelegateCommand(PauseCommand_Execute);
            SkipCommand = new DelegateCommand(SkipCommand_Execute);
            PreviousCommand = new DelegateCommand(PreviousCommand_Execute);
        }

        private void PlayCommand_Execute()
        {

        }

        private void PauseCommand_Execute()
        {

        }

        private void SkipCommand_Execute()
        {

        }

        private void PreviousCommand_Execute()
        {

        }
    }
}
