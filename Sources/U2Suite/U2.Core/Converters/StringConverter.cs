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
using System.Globalization;
using System.Text;

namespace U2.Core;

public static class StringConverter
{
    public static double StringToDouble(string s)
    {
        if (!double.TryParse(s, out double freq)
            && !double.TryParse(s, NumberStyles.Number, CultureInfo.DefaultThreadCurrentUICulture,
                out freq)
            && !double.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out freq))
        {
            freq = 0.0;
        }

        return freq;
    }

    public static decimal StringToDecimal(string s)
    {
        if (!decimal.TryParse(s, out decimal freq)
            && !decimal.TryParse(s, NumberStyles.Number, CultureInfo.DefaultThreadCurrentUICulture,
                out freq)
            && !decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out freq))
        {
            freq = 0.0m;
        }

        return freq;
    }
}
