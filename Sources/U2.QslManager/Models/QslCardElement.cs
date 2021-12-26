using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

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
        /// Coordinates of the lower bottom corner of the element boundary.
        /// Values are in millimeters.
        /// </summary>
        public Position? StartPositionMM { get; set; }
        /// <summary>
        /// Coordinates of the upper-right corner of the element's boundaries.
        /// Values are in millimeters.
        /// Used for images. 
        /// </summary>
        public Position? EndPositionMM { get; set; }
        /// <summary>
        /// A non-negative value indicating the angle of the text transformation.
        /// The value is related to the left-to-right way of the text representation.
        /// </summary>
        public int TransformationAngle { get; set; }
        /// <summary>
        /// Information about the used font (size, color, etc.)
        /// </summary>
        public QslCardElementFont? Font { get; set; }
    }

    public sealed class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    public sealed class QslCardElementFont
    {
        public string? Name { get; set; }
        public int Size { get; set; }
        public string? Color { get; set; }
        public bool Bold { get; set; }
        public bool Italic { get; set; }
    }
}
