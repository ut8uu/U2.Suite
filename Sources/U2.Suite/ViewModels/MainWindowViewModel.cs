using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using U2.Contracts;
using U2.Core;
using U2.Resources;

namespace U2.Suite
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";
        public string QslManagerTitle => "QSL Manager";

        public ReactiveCommand<Unit, Unit> LaunchQslManagerCommand { get; }

        public MainWindowViewModel()
        {
            LaunchQslManagerCommand = ReactiveCommand.Create(LaunchQslManager);
        }

        private void LaunchQslManager()
        {
            LaunchInfo launchInfo = new LaunchInfo
            {
                OsxApplicationPath = ApplicationNames.QslManagerOsx,
                WindowsApplicationPath = ApplicationNames.QslManagerWin,
                LinuxApplicationPath = ApplicationNames.QslManagerLInux
            };

            Launcher.LaunchApplication(launchInfo);
        }

        public void ShowAboutWindow()
        {
            var window = new AboutFormView();
            window.Show();
        }

        public void ShowLicenseWindow()
        {
            var window = new LicenseFormView();
            window.Show();
        }
    }
}
