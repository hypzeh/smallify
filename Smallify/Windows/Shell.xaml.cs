using Smallify.ViewModels;
using Smallify.Windows;
using Squirrel;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Smallify
{
	/// <summary>
	/// Interaction logic for Shell.xaml
	/// </summary>
	public partial class Shell : Window
	{
		public Shell()
		{
			this.DataContext = new ShellViewModel();
			this.InitializeComponent();

			this.MouseDown += this.Shell_MouseDown;
		}

		private void Shell_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
			{
				this.DragMove();
			}
		}
	}
}