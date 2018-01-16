using Prism.Mvvm;

namespace GUI.ViewModels
{
	public class ShellViewModel : BindableBase
	{
		private string _title;

		public ShellViewModel()
		{
			this._title = "Smallify";
		}

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
	}
}