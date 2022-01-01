using System;
using System.Collections.Generic;
using System.Text;

namespace U2.Suite
{
    public sealed class AboutFormViewModel
    {
        public void ShowLicense()
        {
            var window = new LicenseFormView();
            window.Show();
        }
    }
}
