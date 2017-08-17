using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Squirrel;
using System.Diagnostics;

namespace Smallify
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // Package Manager Console> Squirrel --releasify smallify.x.x.x.nupkg --no-msi
            // Check for Squirrel application update
            ReleaseEntry release = null;
            Task.Run(async () =>
            {
                using (var mgr = new UpdateManager("http://nicksmirnoff.co.uk/projects/smallify/install/"))
                {
                    // Check for update
                    UpdateInfo updateInfo = await mgr.CheckForUpdate();

                    // IF Updates to apply
                    if (updateInfo.ReleasesToApply.Any())
                    {
                        System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                        FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

                        // Notify the user there is an update and ask to update.
                        string msg = "New version available!" +
                                        "\n\nCurrent version: " + updateInfo.CurrentlyInstalledVersion.Version +
                                        "\nNew version: " + updateInfo.FutureReleaseEntry.Version +
                                        "\n\nUpdate application now?";
                        DialogResult dialogResult = MessageBox.Show(msg, fvi.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            // Do the update
                            release = await mgr.UpdateApp();
                        }
                    }
                }

                // Restart the app
                if (release != null)
                {
                    UpdateManager.RestartApp();
                }
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Player_Album());
        }
    }
}
