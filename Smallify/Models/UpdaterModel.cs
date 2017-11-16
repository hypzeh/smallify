using NLog;
using Smallify.Interfaces;
using Squirrel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smallify.Models
{
	public static class UpdaterModel
	{
		private const string UpdateURL = @"https://github.com/Hypzeh/Smallify";
		private static Logger GetLogger = LogManager.GetCurrentClassLogger();

		public static async void Setup()
		{
			try
			{
				using (var updateManager = await UpdateManager.GitHubUpdateManager(UpdateURL))
				{
					SquirrelAwareApp.HandleEvents(
						onInitialInstall: v => updateManager.CreateShortcutForThisExe(),
						onAppUpdate: v => updateManager.CreateShortcutForThisExe(),
						onAppUninstall: v => updateManager.RemoveShortcutForThisExe());
				}
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "Update setup failed with Error: {0}", ex.Message);

			}
		}

		public static async Task<string> GetUpdateVersion()
		{
			try
			{
				using (var updateManager = await UpdateManager.GitHubUpdateManager(UpdateURL))
				{
					var updateInfo = await updateManager.CheckForUpdate();

					if (updateInfo.ReleasesToApply.Any())
					{
						return updateInfo.FutureReleaseEntry.Version.ToString();
					}

					return "No Updates";
				}
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "Getting update version failed with Error: {0}", ex.Message);
				return "Failed to retrieve";
			}
		}

		public static async Task<bool> CheckForUpdate()
		{
			try
			{
				using (var updateManager = await UpdateManager.GitHubUpdateManager(UpdateURL))
				{
					var updateInfo = await updateManager.CheckForUpdate();

					if (updateInfo.ReleasesToApply.Any())
					{
						updateManager.Dispose();
						return true;
					}

					updateManager.Dispose();

					return false;
				}
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "Check for updates failed with Error: {0}", ex.Message);
				return false;
			}
		}

		public static async void ApplyUpdate()
		{
			try
			{
				using (var updateManager = await UpdateManager.GitHubUpdateManager(UpdateURL))
				{
					var updateInfo = await updateManager.CheckForUpdate();

					if (updateInfo.ReleasesToApply.Any())
					{
						var update = await updateManager.UpdateApp();

						if (update != null)
						{
							updateManager.Dispose();
							UpdateManager.RestartApp();
						}
					}
				}
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "Applying update failed with Error: {0}", ex.Message);
			}
		}
	}
}
