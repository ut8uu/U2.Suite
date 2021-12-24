using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.QslManager
{
    public partial class QslDesignerPreview : UserControl
    {

        public string PreviewTitle => "Preview";

        public QslDesignerPreview()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
