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

using U2.QslManager.Models;

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
