using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using GalaSoft.MvvmLight.Messaging;
using U2.QslManager.Helpers;

namespace U2.QslManager
{
    [PropertyChanged.DoNotNotify]
    public class QslDesignerPreview : UserControl
    {
        private QslCardDesign _design;
        private RenderTargetBitmap _bitmap;

        private const double ControlWidth = 400.0;

        public QslDesignerPreview()
        {
            InitializeComponent();

            Messenger.Default.Register<RenderQslMessage>(this,
                ReceiveInputMessage);

            _design = new QslCardDesign();
            _bitmap = new RenderTargetBitmap(new PixelSize(1, 1));
        }

        private void ReceiveInputMessage(RenderQslMessage inputMessage)
        {
            Debug.Assert(inputMessage != null);
            Debug.Assert(inputMessage.Fields != null);
            Debug.Assert(inputMessage.Design != null);

            _bitmap = QslCardGenerator.Generate(inputMessage.Fields, inputMessage.Design);
            _design = inputMessage.Design;

            Dispatcher.UIThread.Post(InvalidateVisual, DispatcherPriority.Background);
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
            _bitmap?.Dispose();

            base.OnDetachedFromLogicalTree(e);
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);

            if (_bitmap != null)
            {
                var cardWidth = _design.CardSizeMM.Width * _design.DensityDpmm;
                var cardHeight = _design.CardSizeMM.Height * _design.DensityDpmm;
                var scale = 1.0 * ControlWidth / cardWidth;
                var viewPortWidth = cardWidth * scale;
                var viewPortHeight = cardHeight * scale;

                context.DrawImage(_bitmap,
                    new Rect(0, 0, cardWidth, cardHeight),
                    new Rect(0, 0, viewPortWidth, viewPortHeight));
            }
        }
    }
}
