using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace U2.QslManager
{
    public sealed class QslCardDesign
    {
        public string? DesignName { get; set; }

        public Dimensions? CardSizeMM { get; set; }
        public int DensityDpi { get; set; }

        public QslCardElement[]? Elements { get; set; }
    }

    public sealed class Dimensions
    {
        public Dimensions()
        {

        }

        public int Height { get; set; }
        public int Width { get; set; }

        public Dimensions(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}
