using GUI.Shared.CompositeCommands;
using GUI.Shared.Interfaces;
using Microsoft.Practices.Unity;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Updater.Handlers
{
	class UpdaterHandler
	{
		private readonly IUnityContainer _container;

		public UpdaterHandler(
			IUnityContainer container,
			ICompositeCommandAggregator compositeCommand)
		{
			this._container = container;

			this.InitialiseCommand = new DelegateCommand(this.InitialiseCommand_Execute);
			compositeCommand.Get<UpdaterInitialiseCommand>().RegisterCommand(this.InitialiseCommand);
		}

		public ICommand InitialiseCommand { get; private set; }

		private void InitialiseCommand_Execute()
		{
			var dialog = this._container.Resolve<Window>("UpdaterDialog");
			dialog.Owner = Application.Current.MainWindow;

			dialog.Show();
		}
	}
}
