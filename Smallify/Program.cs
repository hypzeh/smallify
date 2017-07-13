using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Squirrel;

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

            // Squirrel --releasify smallify.x.x.x.nupkg --no-msi
            Task.Run(async () =>
            {
                using (var mgr = new UpdateManager("http://nicksmirnoff.co.uk/projects/smallify/install/"))
                {
                    await mgr.UpdateApp();
                }
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
