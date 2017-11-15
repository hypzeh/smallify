using Smallify.ViewModels;
using Squirrel;
using System.Windows;
using System.Windows.Input;

namespace Smallify.Windows
{
	/// <summary>
	/// Interaction logic for UpdateWindow.xaml
	/// </summary>
	public partial class UpdateWindow : Window
    {
		private UpdateViewModel _updateViewModel;

        public UpdateWindow(UpdateManager updateManager, UpdateInfo updateInfo)
        {
			this._updateViewModel = new UpdateViewModel(updateManager, updateInfo);
			this._updateViewModel.CloseUpdateWindow += this.Close;

            this.InitializeComponent();
			this.DataContext = this._updateViewModel;
			this.MouseDown += this.UpdateWindow_MouseDown;
        }

		private void UpdateWindow_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
			{
				this.DragMove();
			}
		}
	}
}
