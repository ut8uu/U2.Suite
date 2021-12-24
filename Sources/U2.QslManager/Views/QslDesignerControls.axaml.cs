using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.QslManager
{
    public partial class QslDesignerControls : UserControl
    {
        public QslDesignerControls()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
