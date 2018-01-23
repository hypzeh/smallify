using Player.ViewModels;
using System.Windows.Controls;

namespace Player.Views
{
	/// <summary>
	/// Interaction logic for ViewA.xaml
	/// </summary>
	public partial class ViewA : UserControl
	{
		public ViewA(PlayerViewModel viewModel)
		{
			this.DataContext = viewModel;
			this.InitializeComponent();
		}
	}
}