using Smallify.Module.Settings.ViewModels;
using System.Windows.Controls;

namespace Smallify.Module.Settings.Views
{
	public partial class SettingsButtonView : UserControl
	{
		public SettingsButtonView(ISettingsButtonViewModel settingsButtonViewModel)
		{
			InitializeComponent();
			DataContext = settingsButtonViewModel;
		}
	}
}
