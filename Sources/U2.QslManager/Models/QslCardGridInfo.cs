using System.Collections.Generic;

namespace U2.QslManager
{
    public sealed class QslCardGridInfo
    {
        /// <summary>
        /// A color of the background, either hex or color name.
        /// </summary>
        public string? BackgroundColor { get; set; }
        /// <summary>
        /// A color of the line, either hex or color name.
        /// </summary>
        public string? LineColor { get; set; }
        /// <summary>
        /// A number of data rows.
        /// </summary>
        public int? RowCount { get; set; }
        /// <summary>
        /// A height of the header row in millimeters.
        /// </summary>
        public int? HeaderHeightMM { get; set; }
        /// <summary>
        /// A height of the data row in millimeters.
        /// </summary>
        public int? RowHeightMM { get; set; }
        /// <summary>
        /// Bottom left coordinate of the grid in millimeters.
        /// </summary>
        public Position? StartPositionMM { get; set; }
        /// <summary>
        /// A collection of columns.
        /// </summary>
        public List<QslCardGridColumn>? Columns { get; set; }
    }

    public sealed class QslCardGridColumn
    {
        public string? Title { get; set; }
        public int? WidthMM { get; set; }
    }
}