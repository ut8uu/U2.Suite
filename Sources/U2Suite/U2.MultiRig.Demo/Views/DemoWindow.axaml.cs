using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PropertyChanged;
using U2.MultiRig.Demo.ViewModels;

namespace U2.MultiRig.Demo.Views
{
    [DoNotNotify]
    public sealed class DemoWindow : Window
    {
        private DemoViewModel _model;

        public DemoWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            _model = new DemoViewModel
            {
                Owner = this
            };
            this.DataContext = _model;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
