using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using U2.QslManager.Models;

namespace U2.QslManager
{
    public sealed class QslCardDesign
    {
        public QslCardDesign()
        {
            CardSizeMM = new Dimensions();
        }

        public string? AuthoredBy { get; set; }
        public string? DesignName { get; set; }

        public Dimensions CardSizeMM { get; set; }
        public double DensityDpi { get; set; }
        /// <summary>
        /// Contains a density in dots per millimeter.
        /// Read-only property. Is calculated from DensityDpi.
        /// </summary>
        public double DensityDpmm => DensityDpi / 25.4;

        public string? BackgroundColor { get; set; }
        public string? BackgroundImage { get; set; }

        public QslCardElement[]? Elements { get; set; }

        public QslCardToRadio ToRadioBlock { get; set; }

        public QslCardGridInfo? GridInfo { get; set; }
    }

    public sealed class Dimensions
    {
        public Dimensions()
        {

        }

        public double Height { get; set; }
        public double Width { get; set; }

        public Dimensions(double width, double height)
        {
            Height = height;
            Width = width;
        }

        public Avalonia.Size ToSize()
        {
            return new Avalonia.Size(Width, Height);
        }
    }
}
