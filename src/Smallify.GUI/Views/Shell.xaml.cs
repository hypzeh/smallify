using Smallify.GUI.ViewModels;
using System.Windows;

namespace Smallify.GUI.Views
{
	public partial class Shell : Window
	{
		public Shell(IShellViewModel shellViewModel)
		{
			InitializeComponent();
			DataContext = shellViewModel;
		}
	}
}
