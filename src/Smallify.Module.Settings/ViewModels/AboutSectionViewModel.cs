using Prism.Commands;
using Prism.Mvvm;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;

namespace Smallify.Module.Settings.ViewModels
{
    internal class AboutSectionViewModel : BindableBase
    {
        public string Version { get; }
        public ICommand GithubCommand { get; }
        public ICommand ReportIssueCommand { get; }

        public AboutSectionViewModel()
        {
            var version = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            Version = $"v{version.InformationalVersion}";
            GithubCommand = new DelegateCommand(GithubCommand_Execute);
            ReportIssueCommand = new DelegateCommand(ReportIssueCommand_Execute);
        }

        private void GithubCommand_Execute()
        {
            OpenBrowser("https://github.com/hypzeh/smallify");
        }

        private void ReportIssueCommand_Execute()
        {
            OpenBrowser("https://github.com/hypzeh/smallify/issues");
        }

        private static void OpenBrowser(string url)
        {
            // Process Start fails with URL on .NET Core 3: https://github.com/dotnet/corefx/issues/33714
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = $"/c start {url}"
            }); ;
        }
    }
}
