using Smallify.Module.Settings.ViewModels.Sections;
using System.Windows.Controls;

namespace Smallify.Module.Settings.Views.Sections
{
	public partial class About : UserControl
	{
		public About(IAboutViewModel aboutViewModel)
		{
			InitializeComponent();
			DataContext = aboutViewModel;
		}
	}
}
