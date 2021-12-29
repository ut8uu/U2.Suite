using System;
using System.Collections.Generic;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace U2.QslManager.Helpers
{
    public static class DrawingHelper
    {
        public static void DrawText(DrawingContext ctx,
            int densityDpi, double scale,
            string text,
            int textSize,
            int x, int y,
            Color brushColor)
        {
            var brush = new SolidColorBrush(brushColor);
            var point = new Point(x, y) * (densityDpi / 25.4);
            var txt = new FormattedText
            {
                Text = text,
                FontSize = textSize * scale,
                Typeface = new Typeface("Arial"),
            };
            ctx.DrawText(brush, point, txt);
        }

        /// <summary>
        /// Draws a rectangle using a solid color.
        /// </summary>
        /// <param name="ctx">A drawing context</param>
        /// <param name="leftMM">A left coordinate of the rectangle in millimeters</param>
        /// <param name="topMM">A top coordinate of the rectangle in millimeters</param>
        /// <param name="rightMM">A right coordinate of the rectangle in millimeters</param>
        /// <param name="bottomMM">A bottom coordinate of the rectangle in millimeters</param>
        /// <param name="brushColor">Used color</param>
        public static void DrawRectangle(DrawingContext ctx,
            int densityDpi,
            int leftMM, int topMM,
            int rightMM, int bottomMM,
            Color brushColor)
        {
            var brush = new SolidColorBrush(brushColor);
            var dotsPerMM = densityDpi / 25.4;
            var rectangle = new Rect(new Point(leftMM, topMM), 
                new Point(rightMM, bottomMM)) * dotsPerMM;
            ctx.DrawRectangle(brush, null, rectangle);
        }
    }
}
