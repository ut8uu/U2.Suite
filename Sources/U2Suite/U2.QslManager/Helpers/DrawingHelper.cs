using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml;
using Avalonia;
using Avalonia.Media;
using Color = Avalonia.Media.Color;
using Point = Avalonia.Point;

namespace U2.QslManager.Helpers
{
    public static class DrawingHelper
    {
        /// <summary>
        /// Draws given text using the drawing context.
        /// </summary>
        /// <param name="ctx">A context to draw on</param>
        /// <param name="densityDpmm">A density (points per millimeter)</param>
        /// <param name="text">A text to be drawn</param>
        /// <param name="fontName">A name of the used font</param>
        /// <param name="fontSize">A size of the used font</param>
        /// <param name="x">A left position of the text boundaries</param>
        /// <param name="y">A top position of the text boundaries</param>
        /// <param name="colorName">A color of the drawn text</param>
        /// <param name="transformAngle">An angle of the text transformation.</param>
        public static void DrawText(DrawingContext ctx,
            double densityDpmm,
            string text,
            string fontName,
            double fontSize,
            double x, double y,
            string colorName,
            double transformAngle)
        {
            var color = Color.Parse(colorName);
            var brush = new SolidColorBrush(color);
            var point = new Point(x, y) * densityDpmm;
            var txt = new FormattedText
            {
                Text = text,
                FontSize = fontSize,
                Typeface = new Typeface(fontName),
            };
            if (transformAngle > 0)
            {
                RotateTransform rt = new RotateTransform(transformAngle, point.X, point.Y);
                var currentTransform = ctx.CurrentTransform;
                ctx.PushSetTransform(rt.Value);
                ctx.DrawText(brush, point, txt);
                ctx.PushSetTransform(currentTransform);
            }
            else
            {
                ctx.DrawText(brush, point, txt);
            }
        }

        /// <summary>
        /// Draws a rectangle using a solid color.
        /// </summary>
        /// <param name="ctx">A drawing context</param>
        /// <param name="densityDpmm">A density (points per millimeter)</param>
        /// <param name="leftMM">A left coordinate of the rectangle in millimeters</param>
        /// <param name="topMM">A top coordinate of the rectangle in millimeters</param>
        /// <param name="rightMM">A right coordinate of the rectangle in millimeters</param>
        /// <param name="bottomMM">A bottom coordinate of the rectangle in millimeters</param>
        /// <param name="colorName">Used color</param>
        public static void DrawRectangle(DrawingContext ctx,
            double densityDpmm,
            double leftMM, double topMM,
            double rightMM, double bottomMM,
            string colorName)
        {
            var color = Color.Parse(colorName);
            var topLeftPoint = new Point(leftMM, topMM);
            var bottomRightPoint = new Point(rightMM, bottomMM);
            var rectangle = new Rect(topLeftPoint, bottomRightPoint) * densityDpmm;
            DrawRectangle(ctx, rectangle, colorName);
        }

        /// <summary>
        /// Draws a rectangle using a solid color.
        /// </summary>
        /// <param name="ctx">A drawing context</param>
        /// <param name="rectangle">A rectangle to draw</param>
        /// <param name="colorName">Used color</param>
        public static void DrawRectangle(DrawingContext ctx,
            Rect rectangle, string colorName)
        {
            var brushColor = Color.Parse(colorName);
            var brush = new SolidColorBrush(brushColor);
            ctx.DrawRectangle(brush, null, rectangle);
        }
    }
}
