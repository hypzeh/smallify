using Smallify.Module.Player.ViewModels;
using System.Windows.Controls;

namespace Smallify.Module.Player.Views
{
	public partial class PlayerView : UserControl
	{
		public PlayerView()
		{
			InitializeComponent();
			DataContext = new PlayerViewModel();
		}
	}
}
