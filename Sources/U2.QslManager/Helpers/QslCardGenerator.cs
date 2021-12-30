using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Media;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Controls;

namespace U2.QslManager.Helpers
{
    public static class QslCardGenerator
    {
        public static RenderTargetBitmap Generate(
            int density,
            QslCardFieldsModel fields,
            QslCardDesign design)
        {
            var dotsPerMM = density / 25.4;
            var cardWidth = Convert.ToInt32(design.CardSizeMM.Width * dotsPerMM);
            var cardHeight = Convert.ToInt32(design.CardSizeMM.Height * dotsPerMM);
            var scale = 1.0 * 450 / cardWidth;

            var bitmap = new RenderTargetBitmap(new PixelSize(cardWidth, cardHeight),
                new Vector(density, density));

            using var ctxi = bitmap.CreateDrawingContext(null);
            using var ctx = new DrawingContext(ctxi, false);

            ctxi.Clear(default);
            if (!string.IsNullOrEmpty(design.BackgroundColor))
            {
                ctx.FillRectangle(Brush.Parse(design.BackgroundColor), new Rect(0, 0, cardWidth, cardHeight));
            }

            DrawTexts(ctx, fields, design, scale);
            DrawDataGrid(ctx, design, scale);
            DrawToRadio(ctx, design, scale);

            return bitmap;
        }

        private static void DrawToRadio(DrawingContext ctx,
            QslCardDesign design,
            double scale)
        {
            var toRadioBlock = design.ToRadioBlock;
            var dotsPerMM = Convert.ToInt32(design.DensityDpi / 25.4);
            var point = toRadioBlock.StartPositionMM.ToPoint() * dotsPerMM;
            var size = toRadioBlock.Size.ToSize() * dotsPerMM;
            var rectangle = new Rect(point, size);
            if (!string.IsNullOrEmpty(toRadioBlock.BackgroundColor))
            {
                var bgColor = Color.Parse(toRadioBlock.BackgroundColor);
                DrawingHelper.DrawRectangle(ctx, rectangle, bgColor);
            }
            var txt = new FormattedText
            {
                Text = toRadioBlock.ElementTitle,
                FontSize = design.ToRadioBlock.Font.Size / scale,
                Typeface = new Typeface(design.ToRadioBlock.Font.Name),
            };
            var dx = rectangle.X + (rectangle.Height - txt.Bounds.Height);
            var dy = rectangle.Y + rectangle.Height / 2 - txt.Bounds.Height / 2;
            var textPosition = new Point(dx, dy);
            var textBrush = Brush.Parse(toRadioBlock.Font.Color);
            ctx.DrawText(textBrush, textPosition, txt);
        }

        private static void DrawDataGrid(DrawingContext ctx,
            QslCardDesign design,
            double scale)
        {
            if (design.GridInfo == null)
            {
                return;
            }

            var dotsPerMM = Convert.ToInt32(design.DensityDpi / 25.4);
            var currentX = Convert.ToInt32(design.GridInfo.StartPositionMM.X * dotsPerMM);
            var startY = Convert.ToInt32(design.GridInfo.StartPositionMM.Y * dotsPerMM);

            var headerHeight = Convert.ToInt32(design.GridInfo.HeaderHeightMM * dotsPerMM);
            var dataRowHeight = Convert.ToInt32(design.GridInfo.RowHeightMM * dotsPerMM);

            foreach (var column in design.GridInfo.Columns)
            {
                var currentY = startY;

                var columnWidth = Convert.ToInt32(column.WidthMM * dotsPerMM);

                // draw header
                var rectangle = new Rect(new Point(currentX, currentY),
                    new Size(columnWidth, headerHeight));
                DrawDataCell(ctx, design, rectangle, column.Title, scale);

                currentY += headerHeight;

                // draw cells

                for (var rowIndex = 0; rowIndex < design.GridInfo.RowCount; rowIndex++)
                {
                    rectangle = new Rect(new Point(currentX, currentY),
                        new Size(columnWidth, dataRowHeight));
                    DrawDataCell(ctx, design, rectangle, string.Empty, scale);

                    currentY += headerHeight;
                }

                currentX += columnWidth;
            }
        }

        private static void DrawDataCell(DrawingContext ctx,
            QslCardDesign design,
            Rect rectangle,
            string text,
            double scale)
        {
            var cellBrush = Brush.Parse(design.GridInfo.BackgroundColor);
            var textBrush = Brush.Parse(design.GridInfo.ForegroundColor);
            var pen = new Pen(textBrush);
            ctx.DrawRectangle(cellBrush, pen, rectangle);

            var txt = new FormattedText
            {
                Text = text,
                FontSize = design.GridInfo.FontSize.Value / scale,
                Typeface = new Typeface(design.GridInfo.FontName),
            };
            var dx = rectangle.X + rectangle.Width / 2 - txt.Bounds.Width / 2;
            var dy = rectangle.Y + rectangle.Height / 2 - txt.Bounds.Height / 2;
            var textPosition = new Point(dx, dy);
            ctx.DrawText(textBrush, textPosition, txt);
        }

        private static void DrawTexts(DrawingContext? ctx,
            QslCardFieldsModel fields,
            QslCardDesign design,
            double scale)
        {
            if (fields != null)
            {
                DrawText(ctx, design, text: fields.Callsign, elementName: DesignElements.Callsign, scale);
                DrawText(ctx, design, text: fields.OperatorName, elementName: DesignElements.OperatorName, scale);
                DrawText(ctx, design, text: fields.CqZone, elementName: DesignElements.CqZone, scale);
                DrawText(ctx, design, text: fields.ItuZone, elementName: DesignElements.ItuZone, scale);
                DrawText(ctx, design, text: fields.Grid, elementName: DesignElements.Grid, scale);
                DrawText(ctx, design, text: fields.Qth, elementName: DesignElements.Qth, scale);
                DrawText(ctx, design, text: fields.Text1, elementName: DesignElements.Text1, scale);
                DrawText(ctx, design, text: fields.Text2, elementName: DesignElements.Text2, scale);
            }
        }

        private static void DrawText(DrawingContext ctx,
            QslCardDesign design,
            string text,
            string elementName,
            double scale)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            var designElement = design.Elements.GetByName(elementName);
            DrawingHelper.DrawText(ctx, design.DensityDpi, scale * 2,
                $"{designElement.ElementTitle}{text}", designElement.Font.Name, designElement.Font.Size,
                designElement.StartPositionMM.X, designElement.StartPositionMM.Y,
                Color.Parse(designElement.Font.Color));
        }


    }
}
