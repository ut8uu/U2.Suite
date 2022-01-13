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