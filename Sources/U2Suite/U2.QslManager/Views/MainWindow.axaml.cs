using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.QslManager
{
    [PropertyChanged.DoNotNotify]
    public partial class MainWindow : Window
    {
        readonly QslDesignerControls? _designerControls;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            _designerControls = this.FindControl<QslDesignerControls>("DesignerControls");
            _designerControls.SetOwner(this);
            Debug.Assert(_designerControls != null);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
