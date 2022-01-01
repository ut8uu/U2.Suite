using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using U2.Resources;

namespace U2.Suite
{
    public sealed class AboutFormViewModel
    {
        private AboutFormView _owner;

        public AboutFormViewModel(AboutFormView aboutFormView)
        {
            this._owner = aboutFormView;

            var currentDirectory = Path.GetDirectoryName(this.GetType().Assembly.Location);
            var u2SuitePath = Path.Combine(currentDirectory, ApplicationNames.GetSuiteAppName()).Replace("exe", "dll");
            U2SuiteVersion = Assembly.LoadFile(u2SuitePath).GetName().Version.ToString();

            var u2QslManagerPath = Path.Combine(currentDirectory, ApplicationNames.GetSuiteAppName()).Replace("exe", "dll");
            U2QslManagerVersion = Assembly.LoadFile(u2QslManagerPath).GetName().Version.ToString();
        }

        public string U2SuiteVersion { get; set; }
        public string U2QslManagerVersion { get; set; }

        public void ShowLicense()
        {
            var window = new LicenseFormView();
            window.ShowDialog(_owner);
        }
    }
}
