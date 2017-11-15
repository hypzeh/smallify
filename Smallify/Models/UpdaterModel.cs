using Smallify.Interfaces;
using Squirrel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smallify.Models
{
	public class UpdaterModel : IUpdater
	{
		private string _updateVersion;




		public string UpdateVersion
		{
			get
			{
				return this._updateVersion;
			}

			private set
			{
				this._updateVersion = value;
			}
		}

		public bool CheckForUpdates()
		{
			using (var updateManager = GetUpdateManager())
			{
				var updates = updateManager.CheckForUpdate().Result;
				this.UpdateVersion = updates.FutureReleaseEntry.Version.ToString();

				if (updates.ReleasesToApply.Any())
				{
					return true;
				}
			}
			return false;
		}

		public static void PerformUpdate()
		{
			using (var updateManager = GetUpdateManager())
			{
				var updates = updateManager.CheckForUpdate().Result;

				if (updates.ReleasesToApply.Any())
				{
					updateManager.DownloadReleases(updates.ReleasesToApply);
					updateManager.ApplyReleases(updates);
				}
			}
		}

		private static UpdateManager GetUpdateManager()
		{
			return UpdateManager.GitHubUpdateManager("https://github.com/Hypzeh/Smallify").Result;
		}
	}
}
