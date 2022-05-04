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

using System.Collections.Generic;

namespace U2.QslManager
{
    public sealed class QslCardGridInfo
    {
        /// <summary>
        /// A name of the font used in the grid header.
        /// </summary>
        public string FontName { get; set; } = "Arial";

        /// <summary>
        /// A size of the font used in the grid header.
        /// </summary>
        public double FontSize { get; set; } = 12.0;

        /// <summary>
        /// A color of the background, either hex or color name.
        /// </summary>
        public string BackgroundColor { get; set; } = "White";

        /// <summary>
        /// A color of the line, either hex or color name.
        /// </summary>
        public string ForegroundColor { get; set; } = "Black";

        /// <summary>
        /// A number of data rows.
        /// </summary>
        public double RowCount { get; set; } = 1;

        /// <summary>
        /// A height of the header row in millimeters.
        /// </summary>
        public double HeaderHeightMm { get; set; } = 10;

        /// <summary>
        /// A height of the data row in millimeters.
        /// </summary>
        public double RowHeightMm { get; set; } = 10;

        /// <summary>
        /// Bottom left coordinate of the grid in millimeters.
        /// </summary>
        public Position StartPositionMm { get; set; } = new Position(0, 0);

        /// <summary>
        /// A collection of columns.
        /// </summary>
        public List<QslCardGridColumn> Columns { get; set; } = new List<QslCardGridColumn>();
    }

    public sealed class QslCardGridColumn
    {
        public string Title { get; set; } = string.Empty;
        public double WidthMm { get; set; } = 20;
    }
}