using AvaloniaEdit.Editor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using U2.Contracts;
using U2.Core;
using U2.QslManager;
using U2.Resources;

namespace U2.Suite
{
    public sealed class AboutFormViewModel
    {
        private AboutFormView _owner;

        public AboutFormViewModel(AboutFormView aboutFormView)
        {
            this._owner = aboutFormView;

            U2SuiteVersion = new U2SuiteAppVersion().GetAssemblyVersion();
            U2QslManagerVersion = new QslManagerAppVersion().GetAssemblyVersion();
            U2CoreVersion = new U2CoreAppVersion().GetAssemblyVersion();
            U2ContractsVersion = new U2ContractsAppVersion().GetAssemblyVersion();
            U2ResourcesVersion = new U2ResourcesAppVersion().GetAssemblyVersion();
            AvaloniaEditorVersion = new AvaloniaEditorAppVersion().GetAssemblyVersion();
        }

        public string U2SuiteVersion { get; set; }
        public string U2QslManagerVersion { get; set; }
        public string U2CoreVersion { get; set; }
        public string U2ContractsVersion { get; set; }
        public string U2ResourcesVersion { get; set; }
        public string AvaloniaEditorVersion { get; set; }

        public void ShowLicense()
        {
            var window = new LicenseFormView();
            window.ShowDialog(_owner);
        }
    }
}
