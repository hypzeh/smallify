using GUI.Shared.CompositeCommands;
using GUI.Shared.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace Player.ViewModels
{
	public class ViewAViewModel : BindableBase
	{
		private string _message;

		public ViewAViewModel(ICompositeCommandAggregator compositeCommand)
		{
			this.Message = "View A from your Prism Module";

			this.UpdaterWindowCommand = compositeCommand.Get<UpdaterInitialiseCommand>();
		}

		public ICommand UpdaterWindowCommand { get; private set; }

		public string Message
		{
			get
			{
				return this._message;
			}

			set
			{
				this.SetProperty(ref _message, value);
			}
		}
	}
}