using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DynamicData;

namespace U2.Core
{
    public static class StringConverter
    {
        public static double StringToDouble(string s)
        {
            var freq = 0.0;
            if (!double.TryParse(s, out freq)
                && !double.TryParse(s, NumberStyles.Number, CultureInfo.DefaultThreadCurrentUICulture,
                    out freq)
                && !double.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out freq))
            {
                freq = 0.0;
            }

            return freq;
        }
    }
}
