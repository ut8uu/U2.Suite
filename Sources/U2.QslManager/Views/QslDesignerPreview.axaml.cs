using System;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Media.Immutable;
using Avalonia.Media;
using Avalonia.Threading;
using System.Runtime.InteropServices;
using Avalonia.Platform;
using GalaSoft.MvvmLight.Messaging;
using Avalonia.LogicalTree;
using U2.QslManager.Helpers;

namespace U2.QslManager
{
    [PropertyChanged.DoNotNotify]
    public partial class QslDesignerPreview : UserControl
    {

        private QslCardFieldsModel _fields = null;
        private QslCardDesign _design = null;
        private RenderTargetBitmap _bitmap;
        private int _cardWidth;
        private int _cardHeight;
        private int _viewPortWidth;
        private int _viewPortHeight;
        private double _scale;

        private const int ControlWidth = 400;

        public QslDesignerPreview()
        {
            InitializeComponent();

            Messenger.Default.Register<RenderQslMessage>(this,
                ReceiveInputMessage);
        }

        private void ReceiveInputMessage(RenderQslMessage inputMessage)
        {
            Debug.Assert(inputMessage != null);
            Debug.Assert(inputMessage.Fields != null);
            Debug.Assert(inputMessage.Design != null);

            _fields = inputMessage.Fields;
            var designHasChanged = (_design == null
                                    || _design.DensityDpi != inputMessage.Design.DensityDpi
                                    || _design.CardSizeMM.Width != inputMessage.Design.CardSizeMM.Width
                                    || _design.CardSizeMM.Height != inputMessage.Design.CardSizeMM.Height);
            _design = inputMessage.Design;

            var dotsPerMM = _design.DensityDpi / 25.4;
            _cardWidth = Convert.ToInt32(_design.CardSizeMM.Width * dotsPerMM);
            _cardHeight = Convert.ToInt32(_design.CardSizeMM.Height * dotsPerMM);
            _scale = 1.0 * ControlWidth / _cardWidth;
            _viewPortWidth = Convert.ToInt32(_cardWidth * _scale);
            _viewPortHeight = Convert.ToInt32(_cardHeight * _scale);

            if (designHasChanged)
            {
                if (_bitmap != null)
                {
                    _bitmap.Dispose();
                    _bitmap = null;
                }
                _bitmap = new RenderTargetBitmap(new PixelSize(_cardWidth, _cardHeight),
                    new Vector(_design.DensityDpi, _design.DensityDpi));
            }

            using var ctxi = _bitmap.CreateDrawingContext(null);
            using var ctx = new DrawingContext(ctxi, false);

            ctxi.Clear(default);
            if (!string.IsNullOrEmpty(_design.BackgroundColor))
            {
                ctx.FillRectangle(Brush.Parse(_design.BackgroundColor), new Rect(0, 0, _cardWidth, _cardHeight));
            }

            DrawTexts(ctx);
            DrawDataGrid(ctx);

            Dispatcher.UIThread.Post(InvalidateVisual, DispatcherPriority.Background);
        }

        private void DrawDataGrid(DrawingContext ctx)
        {
            if (_design.GridInfo == null)
            {
                return;
            }

            var dotsPerMM = Convert.ToInt32(_design.DensityDpi / 25.4);
            var currentX = Convert.ToInt32(_design.GridInfo.StartPositionMM.X * dotsPerMM);
            var startY = Convert.ToInt32(_design.GridInfo.StartPositionMM.Y * dotsPerMM);

            var headerHeight = Convert.ToInt32(_design.GridInfo.HeaderHeightMM * dotsPerMM);
            var dataRowHeight = Convert.ToInt32(_design.GridInfo.RowHeightMM * dotsPerMM);

            foreach (var column in _design.GridInfo.Columns)
            {
                var currentY = startY;

                var columnWidth = Convert.ToInt32(column.WidthMM * dotsPerMM);

                // draw header
                var rectangle = new Rect(new Point(currentX, currentY),
                    new Size(columnWidth, headerHeight));
                DrawDataCell(ctx, rectangle, column.Title);

                currentY += headerHeight;

                // draw cells

                for (var rowIndex = 0; rowIndex < _design.GridInfo.RowCount; rowIndex++)
                {
                    rectangle = new Rect(new Point(currentX, currentY),
                        new Size(columnWidth, dataRowHeight));
                    DrawDataCell(ctx, rectangle, string.Empty);

                    currentY += headerHeight;
                }

                currentX += columnWidth;
            }
        }

        private void DrawDataCell(DrawingContext ctx, Rect rectangle, string text)
        {
            var cellBrush = Brush.Parse(_design.GridInfo.BackgroundColor);
            var textBrush = Brush.Parse(_design.GridInfo.ForegroundColor);
            var pen = new Pen(textBrush);
            ctx.DrawRectangle(cellBrush, pen, rectangle);

            var txt = new FormattedText
            {
                Text = text,
                FontSize = _design.GridInfo.FontSize.Value / _scale,
                Typeface = new Typeface(_design.GridInfo.FontName),
            };
            var dx = rectangle.X + rectangle.Width / 2 - txt.Bounds.Width / 2;
            var dy = rectangle.Y + rectangle.Height / 2 - txt.Bounds.Height / 2;
            var textPosition = new Point(dx, dy);
            ctx.DrawText(textBrush, textPosition, txt);
        }

        private void DrawTexts(DrawingContext? ctx)
        {
            if (_fields != null)
            {
                DrawText(ctx, text: _fields.Callsign, DesignElements.Callsign);
                DrawText(ctx, text: _fields.OperatorName, DesignElements.OperatorName);
                DrawText(ctx, text: _fields.CqZone, DesignElements.CqZone);
                DrawText(ctx, text: _fields.ItuZone, DesignElements.ItuZone);
                DrawText(ctx, text: _fields.Grid, DesignElements.Grid);
                DrawText(ctx, text: _fields.Qth, DesignElements.Qth);
                DrawText(ctx, text: _fields.Text1, DesignElements.Text1);
                DrawText(ctx, text: _fields.Text2, DesignElements.Text2);
            }
        }

        private void DrawText(DrawingContext ctx, string text, string elementName)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            var designElement = _design.Elements.GetByName(elementName);
            DrawingHelper.DrawText(ctx, _design.DensityDpi, _scale * 2,
                $"{designElement.ElementTitle}{text}", designElement.Font.Name, designElement.Font.Size,
                designElement.StartPositionMM.X, designElement.StartPositionMM.Y,
                Color.Parse(designElement.Font.Color));
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e)
        {
            base.OnAttachedToLogicalTree(e);
        }

        protected override void OnDetachedFromLogicalTree(LogicalTreeAttachmentEventArgs e)
        {
            if (_bitmap != null)
            {
                _bitmap.Dispose();
                _bitmap = null;
            }

            base.OnDetachedFromLogicalTree(e);
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);

            if (_bitmap != null)
            {
                context.DrawImage(_bitmap,
                    new Rect(0, 0, _cardWidth, _cardHeight),
                    new Rect(0, 0, _viewPortWidth, _viewPortHeight));
            }
        }
    }
}
