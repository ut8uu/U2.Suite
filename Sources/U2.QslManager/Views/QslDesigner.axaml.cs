using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.QslManager
{
    [PropertyChanged.DoNotNotify]
    public partial class QslDesigner : UserControl
    {
        public QslDesigner()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
