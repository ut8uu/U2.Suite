using System;
using System.Collections.Generic;
using System.Text;

namespace U2.Core.Helpers
{
    public abstract class AppVersionHelper
    {
        public string GetAssemblyVersion()
        {
            return this.GetType().Assembly.GetName().Version.ToString();
        }
    }
}
