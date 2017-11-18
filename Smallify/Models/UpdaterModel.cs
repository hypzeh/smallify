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

		public static async Task Setup()
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
				GetLogger.Error(ex, "[UPDATER] Failed to setup: {0}", ex.Message);
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
				GetLogger.Error(ex, "[UPDATER] Failed to get update version: {0}", ex.Message);
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
						return true;
					}
					
					return false;
				}
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "[UPDATER] Failed to check for update(s): {0}", ex.Message);
				return false;
			}
		}

		public static async Task ApplyUpdate()
		{
			try
			{
				using (var updateManager = await UpdateManager.GitHubUpdateManager(UpdateURL))
				{
					var updateInfo = await updateManager.CheckForUpdate();

					if (updateInfo.ReleasesToApply.Any())
					{
						await updateManager.UpdateApp();
					}
				}

				UpdateManager.RestartApp();
			}
			catch (Exception ex)
			{
				GetLogger.Error(ex, "[UPDATER] Failed to apply update(s): {0}", ex.Message);
			}
		}
	}
}
