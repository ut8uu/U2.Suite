using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.Logger.Tests
{
    internal class LogInfoTestHelper
    {
        internal static LogInfo GetLogInfo()
        {
            return new LogInfo
            {
                Description = String.Empty,
                LogName = AppSettings.Default.LogName,
                StationCallsign = "UT8UU/P",
                OperatorCallsign = "UT8UU",
                ActivatedReference = "URFF-0100",
            };
        }
    }
}
