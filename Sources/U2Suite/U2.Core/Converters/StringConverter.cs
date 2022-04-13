using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DynamicData;

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
