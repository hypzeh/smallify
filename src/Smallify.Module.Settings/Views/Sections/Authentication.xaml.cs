using Smallify.Module.Settings.ViewModels;
using System.Windows.Controls;

namespace Smallify.Module.Settings.Views.Sections
{
	public partial class Authentication : UserControl
	{
		public Authentication(IAuthenticationViewModel authenticationViewModel)
		{
			InitializeComponent();
			DataContext = authenticationViewModel;
		}
	}
}
