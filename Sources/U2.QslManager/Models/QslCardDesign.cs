using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace U2.QslManager
{
    public sealed class QslCardDesign
    {
        public string? DesignName { get; set; }

        public Size CardSizeMM { get; set; }
        public int DensityDpi { get; set; }

        public QslCardElement[]? Elements { get; set; }
    }
}
