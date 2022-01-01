using System;
using System.Collections.Generic;
using System.Text;

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
