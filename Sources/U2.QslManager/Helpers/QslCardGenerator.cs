using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Media;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Controls;
using System.Drawing.Imaging;
using Avalonia.Controls.Shapes;

namespace U2.QslManager.Helpers
{
    public static class QslCardGenerator
    {
        public const double ViewPortWidth = 450;

        public static RenderTargetBitmap Generate(
            QslCardFieldsModel fields,
            QslCardDesign design)
        {
            var cardWidth = Convert.ToInt32(design.CardSizeMM.Width * design.DensityDpmm);
            var cardHeight = Convert.ToInt32(design.CardSizeMM.Height * design.DensityDpmm);
            var scale = 1.0;// ViewPortWidth / cardWidth;

            var bitmap = new RenderTargetBitmap(new PixelSize(cardWidth, cardHeight),
                new Vector(design.DensityDpi, design.DensityDpi));

            using var ctxi = bitmap.CreateDrawingContext(null);
            using var ctx = new DrawingContext(ctxi, false);

            ctxi.Clear(default);
            if (!string.IsNullOrEmpty(design.BackgroundColor))
            {
                ctx.FillRectangle(Brush.Parse(design.BackgroundColor), new Rect(0, 0, cardWidth, cardHeight));
            }

            DrawBackgroundImage(ctx, fields, design);
            DrawTexts(ctx, fields, design, scale);
            DrawDataGrid(ctx, design, scale);
            DrawToRadio(ctx, design, scale);

            return bitmap;
        }

        private static void DrawBackgroundImage(
            DrawingContext ctx, 
            QslCardFieldsModel fields, 
            QslCardDesign design)
        {
            if (string.IsNullOrEmpty(fields.BackgroundImage))
            {
                return;
            }

            var image = System.Drawing.Image.FromFile(fields.BackgroundImage);
            var bitmapTmp = new System.Drawing.Bitmap(image);
            var bitmapdata = bitmapTmp.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmapTmp.Width, bitmapTmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            var avaloniaBitmap = new Bitmap(Avalonia.Platform.PixelFormat.Bgra8888, Avalonia.Platform.AlphaFormat.Premul,
                bitmapdata.Scan0,
                new Avalonia.PixelSize(bitmapdata.Width, bitmapdata.Height),
                new Avalonia.Vector(design.DensityDpi, design.DensityDpi),
                bitmapdata.Stride);
            bitmapTmp.UnlockBits(bitmapdata);
            bitmapTmp.Dispose();
            
            var srcW = avaloniaBitmap.Size.Width;
            var srcH = avaloniaBitmap.Size.Height;
            var scale0 = srcW / srcH;

            var destStartX = 0d;
            var destStartY = 0d;
            var destEndX = design.CardSizeMM.Width * design.DensityDpmm;
            var destEndY = design.CardSizeMM.Height * design.DensityDpmm;
            var scale1 = destEndX / destEndY;

            if (scale0 > scale1)
            {
                // source image is wider than destination
                var ratioH = srcH / destEndY;
                var resultingW = srcW / ratioH;
                var deltaW = (resultingW - destEndX) / 2;
                destStartX = -deltaW;
                destEndX += deltaW;
            }
            else
            {
                // source image is higher than destination
                var ratioW = srcW / destEndX;
                var resultingH = srcH / ratioW;
                var deltaH = (resultingH - destEndY) / 2;
                destStartY = -deltaH;
                destEndY += deltaH;
            }

            var sourceRectangle = new Rect(new Point(0, 0), avaloniaBitmap.Size);
            var destinationRectangle = new Rect(
                new Point(destStartX, destStartY),
                new Point(destEndX, destEndY));
            ctx.DrawImage(avaloniaBitmap, sourceRectangle, destinationRectangle);
        }

        private static void DrawToRadio(DrawingContext ctx,
            QslCardDesign design,
            double scale)
        {
            var toRadioBlock = design.ToRadioBlock;
            var point = toRadioBlock.StartPositionMM.ToPoint() * design.DensityDpmm;
            var size = toRadioBlock.Size.ToSize() * design.DensityDpmm;
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

            var currentX = Convert.ToInt32(design.GridInfo.StartPositionMM.X * design.DensityDpmm);
            var startY = Convert.ToInt32(design.GridInfo.StartPositionMM.Y * design.DensityDpmm);

            var headerHeight = Convert.ToInt32(design.GridInfo.HeaderHeightMM * design.DensityDpmm);
            var dataRowHeight = Convert.ToInt32(design.GridInfo.RowHeightMM * design.DensityDpmm);

            foreach (var column in design.GridInfo.Columns)
            {
                var currentY = startY;

                var columnWidth = Convert.ToInt32(column.WidthMM * design.DensityDpmm);

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
