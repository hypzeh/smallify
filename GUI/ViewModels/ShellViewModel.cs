using GUI.Shared.Constants;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace GUI.ViewModels
{
	public class ShellViewModel : BindableBase
	{
		private readonly IRegionManager _regionManager;
		private string _title;

		public ShellViewModel(IRegionManager regionManager)
		{
			this._regionManager = regionManager;

			this._title = "Smallify";

			this.SwitchPlayerCommand = new DelegateCommand<string>(this.SwitchPlayerCommand_Execute);
		}

		public ICommand SwitchPlayerCommand { get; private set; }

		public string Title
		{
			get
			{
				return this._title;
			}

			set
			{
				this.SetProperty(ref this._title, value);
			}
		}

		public void SwitchPlayerCommand_Execute(string playerRequest)
		{
			this._regionManager.RequestNavigate(RegionNames.PlayerRegion, playerRequest);
		}
	}
}