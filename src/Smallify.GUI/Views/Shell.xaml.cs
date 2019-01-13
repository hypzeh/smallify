using Smallify.GUI.ViewModels;
using System.Windows;

namespace Smallify.GUI.Views
{
	public partial class Shell : Window
	{
		public Shell()
		{
			InitializeComponent();
			DataContext = new ShellViewModel();
		}
	}
}
