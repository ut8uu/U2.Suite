using System;
using System.Collections.Generic;
using System.Text;

namespace U2.Contracts
{
    public sealed class U2ContractsAppVersion
    {
        public string GetAssemblyVersion()
        {
            return this.GetType().Assembly.GetName().Version.ToString();
        }
    }
}
