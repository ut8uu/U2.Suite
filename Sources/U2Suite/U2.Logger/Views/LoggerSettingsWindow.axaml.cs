using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Logger
{
    [PropertyChanged.DoNotNotify]
    public partial class LoggerSettingsWindow : Window
    {
        private LoggerSettingsViewModel _viewModel;

        public LoggerSettingsWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            _viewModel = new LoggerSettingsViewModel();
            DataContext = _viewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
