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
using static System.Net.Mime.MediaTypeNames;

namespace U2.QslManager
{
    [PropertyChanged.DoNotNotify]
    public partial class QslDesignerPreview : UserControl
    {

        private QslCardFieldsModel _fields = null;
        private QslCardDesign _design = null;
        private RenderTargetBitmap _bitmap;

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

            var designHasChanged = (_design == null
                                    || _design.DensityDpi != inputMessage.Design.DensityDpi
                                    || _design.CardSizeMM.Width != inputMessage.Design.CardSizeMM.Width
                                    || _design.CardSizeMM.Height != inputMessage.Design.CardSizeMM.Height);

            _bitmap = QslCardGenerator.Generate(96, inputMessage.Fields, inputMessage.Design);

            _fields = inputMessage.Fields;
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
                var dotsPerMM = _design.DensityDpi / 25.4;
                var cardWidth = Convert.ToInt32(_design.CardSizeMM.Width * dotsPerMM);
                var cardHeight = Convert.ToInt32(_design.CardSizeMM.Height * dotsPerMM);
                var scale = 1.0 * ControlWidth / cardWidth;
                var viewPortWidth = Convert.ToInt32(cardWidth * scale);
                var viewPortHeight = Convert.ToInt32(cardHeight * scale);

                context.DrawImage(_bitmap,
                    new Rect(0, 0, cardWidth, cardHeight),
                    new Rect(0, 0, viewPortWidth, viewPortHeight));
            }
        }
    }
}
