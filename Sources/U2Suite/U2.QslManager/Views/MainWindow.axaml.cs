using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Diagnostics;

namespace U2.QslManager
{
    [PropertyChanged.DoNotNotify]
    public partial class MainWindow : Window
    {
        QslDesignerControls? _designerControls;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            _designerControls = this.FindControl<QslDesignerControls>("DesignerControls");
            Debug.Assert(_designerControls != null);
            _designerControls.SetOwner(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
