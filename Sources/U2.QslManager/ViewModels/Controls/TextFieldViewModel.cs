using System;
using System.Collections.Generic;
using System.Text;

namespace U2.QslManager.ViewModels.Controls
{
    public sealed class TextFieldViewModel
    {
        /// <summary>
        /// A name of the control
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// A text to be displayed
        /// </summary>
        public string? Text { get; set; }
        /// <summary>
        /// A name of the used font
        /// </summary>
        public string? FontFamily { get; set; }
        /// <summary>
        /// A color of the text
        /// </summary>
        public string? FontColor { get; set; }
        /// <summary>
        /// A positive size of the font
        /// </summary>
        public int FontSize { get; set; }
        /// <summary>
        /// A non-negative value indicating the direction of the text.
        /// 0 - up, 90 - right, 180 - down, 270 - left, upside down
        /// 45 - up-right, and so on
        /// </summary>
        public int Angle { get; set; }
        /// <summary>
        /// Indicates whether the text should be bold
        /// </summary>
        public bool Bold { get; set; }
        /// <summary>
        /// Indicates whether the text should be italic
        /// </summary>
        public bool Italic { get; set; }
        /// <summary>
        /// A maximal width of the displayed text
        /// </summary>
        public int MaxWidth { get; set; }
        /// <summary>
        /// Indicates whether the field should be rendered
        /// </summary>
        public bool Visible { get; set; }
    }
}
