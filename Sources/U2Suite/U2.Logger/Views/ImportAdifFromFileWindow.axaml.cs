using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Logger
{
    [PropertyChanged.DoNotNotify]
    public partial class ImportAdifFromFileWindow : Window
    {
        ImportAdifFromFileViewModel _viewModel;

        public ImportAdifFromFileWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _viewModel = new ImportAdifFromFileViewModel();
            this.DataContext = _viewModel;
            _viewModel.Owner = this;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
