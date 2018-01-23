using Player.ViewModels;
using System.Windows.Controls;

namespace Player.Views
{
	/// <summary>
	/// Interaction logic for BarPlayerView.xaml
	/// </summary>
	public partial class BarPlayerView : UserControl
	{
		public BarPlayerView(PlayerViewModel viewModel)
		{
			this.DataContext = viewModel;
			this.InitializeComponent();
		}
	}
}