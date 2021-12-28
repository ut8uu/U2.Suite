using System.Diagnostics;
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

namespace U2.QslManager
{
    [PropertyChanged.DoNotNotify]
    public partial class QslDesignerPreview : UserControl
    {
        private bool _drawn = false;
        private QslCardFieldsModel _fields = null;
        private QslCardDesign _design = null;
        private RenderTargetBitmap _bitmap;

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
            _design = inputMessage.Design;
            _drawn = false;
            this.InvalidateVisual();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e)
        {
            _bitmap = new RenderTargetBitmap(new PixelSize(800, 600), new Vector(96, 96));
            base.OnAttachedToLogicalTree(e);
        }

        protected override void OnDetachedFromLogicalTree(LogicalTreeAttachmentEventArgs e)
        {
            _bitmap.Dispose();
            _bitmap = null;
            base.OnDetachedFromLogicalTree(e);
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);

            context.FillRectangle(Brushes.Yellow, new Rect(0, 0, 800, 600));

            if (!_drawn && _fields != null)
            {
                using var ctxi = _bitmap.CreateDrawingContext(null);
                using var ctx = new DrawingContext(ctxi, false);

                ctxi.Clear(default);
                ctx.FillRectangle(Brushes.White, new Rect(0, 0, 800, 600));
                var brush = new SolidColorBrush(Colors.Black);
                var point = new Point(50, 10);
                var text = new FormattedText
                {
                    Text = _fields.Callsign,
                    FontSize = 40,
                    Typeface = new Typeface("Arial"),
                };
                ctx.DrawText(brush, point, text);
                _drawn = true;
            }

            context.DrawImage(_bitmap,
                new Rect(0, 0, 800, 600),
                new Rect(0, 0, 800, 600));

            Dispatcher.UIThread.Post(InvalidateVisual, DispatcherPriority.Background);
        }
    }
}
