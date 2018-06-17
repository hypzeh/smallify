using Player.ViewModels;
using System.Windows.Controls;

namespace Player.Views
{
	/// <summary>
	/// Interaction logic for SpotifyPlayerView.xaml
	/// </summary>
	public partial class SpotifyPlayerView : UserControl
	{
		public SpotifyPlayerView(PlayerViewModel viewModel)
		{
			this.DataContext = viewModel;
			this.InitializeComponent();
		}
	}
}