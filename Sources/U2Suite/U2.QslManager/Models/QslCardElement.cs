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

namespace U2.QslManager
{
    public enum QslCardElementType
    {
        Text,
        Image,
    }

    public class QslCardElement
    {
        /// <summary>
        /// An order of the element during the processing.
        /// Can be either positive or negative.
        /// By default is 0.
        /// </summary>
        public int Order { get; set; } = 0;
        /// <summary>
        /// A type of the element.
        /// </summary>
        public QslCardElementType ElementType { get; set; } = QslCardElementType.Text;
        /// <summary>
        /// A name of the element
        /// </summary>
        public string? ElementName { get; set; }
        /// <summary>
        /// A title of the element to be shown on the card.
        /// </summary>
        public string? ElementTitle { get; set; }

        /// <summary>
        /// Coordinates of the lower bottom corner of the element boundary.
        /// Values are in millimeters.
        /// </summary>
        public Position StartPositionMm { get; set; } = new Position(0, 0);
        /// <summary>
        /// Coordinates of the upper-right corner of the element's boundaries.
        /// Values are in millimeters.
        /// Used for images. 
        /// </summary>
        public Position EndPositionMm { get; set; } = new Position();
        /// <summary>
        /// A size of the bounding box.
        /// </summary>
        public Dimensions Size { get; set; } = new Dimensions();
        /// <summary>
        /// A non-negative value indicating the angle of the text transformation.
        /// The value is related to the left-to-right way of the text representation.
        /// </summary>
        public int TransformationAngle { get; set; }

        /// <summary>
        /// Information about the used font (size, color, etc.)
        /// </summary>
        public QslCardElementFont Font { get; set; } = new QslCardElementFont();
    }

    public sealed class Position
    {
        public Position() { }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public Avalonia.Point ToPoint()
        {
            return new Avalonia.Point(X, Y);
        }
    }

    public sealed class QslCardElementFont
    {
        public string Name { get; set; } = "Arial";
        public double Size { get; set; } = 12;
        public string Color { get; set; } = "Black";
        public bool Bold { get; set; }
        public bool Italic { get; set; }
    }
}
