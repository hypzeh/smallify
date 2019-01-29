using Smallify.Module.Settings.ViewModels.Sections;
using System.Windows.Controls;

namespace Smallify.Module.Settings.Views.Sections
{
	public partial class General : UserControl
	{
		public General(IGeneralViewModel generalViewModel)
		{
			InitializeComponent();
			DataContext = generalViewModel;
		}
	}
}
