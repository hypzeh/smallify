using Smallify.Module.Settings.ViewModels;
using System.Windows.Controls;

namespace Smallify.Module.Settings.Views
{
	public partial class SettingsView : UserControl
	{
		public SettingsView()
		{
			InitializeComponent();
			DataContext = new SettingsViewModel();
		}
	}
}
