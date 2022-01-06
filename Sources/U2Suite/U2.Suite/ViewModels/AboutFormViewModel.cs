using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using U2.Contracts;
using U2.Core;
using U2.Resources;

namespace U2.Suite
{
    public sealed class AboutFormViewModel
    {
        private AboutFormView _owner;

        public AboutFormViewModel(AboutFormView aboutFormView)
        {
            this._owner = aboutFormView;
        }

        public void ShowLicense()
        {
            var window = new LicenseFormView();
            window.ShowDialog(_owner);
        }
    }
}
