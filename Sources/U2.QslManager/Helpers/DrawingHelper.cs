using System;
using System.Collections.Generic;
using System.Text;
using Avalonia;
using Avalonia.Media;

namespace U2.QslManager.Helpers
{
    public static class DrawingHelper
    {
        public static void DrawText(DrawingContext ctx, 
            string text,
            int textSize,
            int x, int y,
            Color brushColor)
        {
            var brush = new SolidColorBrush(brushColor);
            var point = new Point(x, y);
            var txt = new FormattedText
            {
                Text = text,
                FontSize = textSize,
                Typeface = new Typeface("Arial"),
            };
            ctx.DrawText(brush, point, txt);
        }
    }
}
