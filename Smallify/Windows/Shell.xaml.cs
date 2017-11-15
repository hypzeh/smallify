using Smallify.Windows;
using Squirrel;
using System.Linq;
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

		private void Shell_Loaded(object sender, RoutedEventArgs e)
		{
			// Package Manager Console> Squirrel --releasify smallify.1.0.0.nupkg --setupIcon D:\Development\Projects\Smallify\Smallify\Resources\Icon\Smallify_Default.ico --no-msi
			// Check for Squirrel application update
			Task.Run(async () =>
			{
				using (var updateManger = UpdateManager.GitHubUpdateManager("https://github.com/Hypzeh/Smallify"))
				{
					SquirrelAwareApp.HandleEvents(
						onInitialInstall: v => updateManger.Result.CreateShortcutForThisExe(),
						onAppUpdate: v => updateManger.Result.CreateShortcutForThisExe(),
						onAppUninstall: v => updateManger.Result.RemoveShortcutForThisExe());

					// Check for updates
					var updateInfo = await updateManger.Result.CheckForUpdate().ConfigureAwait(true);

					// IF Updates found open update window
					if (updateInfo.ReleasesToApply.Any())
					{
						var updateWindow = new UpdateWindow(updateManger.Result, updateInfo);
						updateWindow.Show();
						updateWindow.Activate();
					}
				};
			});
		}
	}
}