namespace U2.Resources.Collections
{
    public sealed class VendorIds
    {
        public const int AlincoId = 1;
        public const int IcomId = AlincoId + 1;
        public const int KenwoodId = IcomId + 1;
        public const int MotorolaId = KenwoodId + 1;
        public const int TenTecId = MotorolaId + 1;
        public const int WouxunId = TenTecId + 1;
        public const int YaesuId = WouxunId + 1;
    }

    public sealed class VendorNames
    {
        public const string Alinco = nameof(Alinco);
        public const string Icom = nameof(Icom);
        public const string Kenwood = nameof(Kenwood);
        public const string Motorola = nameof(Motorola);
        public const string TenTec = nameof(TenTec);
        public const string Wouxun = nameof(Wouxun);
        public const string Yaesu = nameof(Yaesu);
    }
}
