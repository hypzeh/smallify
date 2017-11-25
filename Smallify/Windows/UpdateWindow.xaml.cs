using Smallify.ViewModels;
using Squirrel;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Smallify.Windows
{
	/// <summary>
	/// Interaction logic for UpdateWindow.xaml
	/// </summary>
	public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
			var updateVM = new UpdateViewModel();
			updateVM.CloseUpdateWindow += this.UpdateVM_CloseUpdateWindow;
			updateVM.ShowUpdateWindow += this.UpdateView_ShowUpdateWindow;

			this.DataContext = updateVM;
            this.InitializeComponent();

			this.MouseDown += this.UpdateWindow_MouseDown;
		}
		private void UpdateVM_CloseUpdateWindow()
		{
			this.Dispatcher.Invoke(() =>
			{
				this.Close();
			}, DispatcherPriority.Normal);
		}

		private void UpdateView_ShowUpdateWindow()
		{
			this.Dispatcher.Invoke(() =>
			{
				this.Show();
				this.Activate();
			}, DispatcherPriority.Normal);
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
