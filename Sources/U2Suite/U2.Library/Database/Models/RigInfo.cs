using System;
using System.Collections.Generic;
using System.Text;

namespace U2.Library
{
    public sealed class RigInfo
    {
        public RigInfo() { }

        public string Manufacturer { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Modes { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string Power { get; set; } = default!;
        public string Dimensions { get; set; } = default!;
        public string Frequency { get; set; } = default!;
        public string Image { get; set; } = default!;
        public string Weight { get; set; } = default!;
    }
}
