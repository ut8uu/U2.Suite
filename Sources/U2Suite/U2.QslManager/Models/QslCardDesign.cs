﻿using U2.QslManager.Models;

namespace U2.QslManager
{
    public sealed class QslCardDesign
    {
        public QslCardDesign() { }

        public QslCardDesign(QslCardDesign design)
        {
            AuthoredBy = design.AuthoredBy;
            DesignName = design.DesignName;
            DesignLocation = design.DesignLocation;
            CardSizeMM = new Dimensions(design.CardSizeMM.Width, design.CardSizeMM.Height);

        }

        public string? AuthoredBy { get; set; }
        public string? DesignName { get; set; }
        public string DesignLocation { get; set; } = string.Empty;

        public Dimensions CardSizeMM { get; set; } = new Dimensions();
        public double DensityDpi { get; set; }
        /// <summary>
        /// Contains a density in dots per millimeter.
        /// Read-only property. Is calculated from DensityDpi.
        /// </summary>
        public double DensityDpmm => DensityDpi / 25.4;

        public string BackgroundColor { get; set; } = "White";
        public string? BackgroundImage { get; set; }

        public QslCardElement[]? Elements { get; set; }

        public QslCardToRadio ToRadioBlock { get; set; } = new QslCardToRadio();

        public QslCardGridInfo GridInfo { get; set; } = new QslCardGridInfo();
    }

    public sealed class Dimensions
    {
        public Dimensions()
        {

        }

        public Dimensions(double width, double height)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; set; }
        public double Width { get; set; }

        public Avalonia.Size ToSize()
        {
            return new Avalonia.Size(Width, Height);
        }
    }
}
