using System;
using System.Collections.Generic;
using System.Text;

namespace U2.Resources.Collections
{
    public sealed class VendorIds
    {
        public const int AlincoId = 1;
        public const int IcomId = AlincoId + 1;
        public const int KenwoodId = IcomId + 1;
        public const int YaesuId = KenwoodId + 1;
    }

    public sealed class VendorNames
    {
        public const string Alinco = nameof(Alinco);
        public const string Icom = nameof(Icom);
        public const string Kenwood = nameof(Kenwood);
        public const string Yaesu = nameof(Yaesu);
    }
}
