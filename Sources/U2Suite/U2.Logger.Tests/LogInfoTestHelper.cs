/* 
 * This file is part of the U2.Suite distribution
 * (https://github.com/ut8uu/U2.Suite).
 * 
 * Copyright (c) 2022 Sergey Usmanov, UT8UU.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

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
                LogName = LoggerAppSettings.Default.LogName,
                StationCallsign = "UT8UU/P",
                OperatorCallsign = "UT8UU",
                ActivatedReference = "URFF-0100",
            };
        }
    }
}
