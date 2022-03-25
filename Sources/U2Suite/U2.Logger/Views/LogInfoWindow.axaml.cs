using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Logger
{
    [PropertyChanged.DoNotNotify]
    public partial class LogInfoWindow : Window
    {
        LogInfoWindowViewModel _viewModel;

        public LogInfoWindow() 
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        public LogInfoWindow(CommandToExecute commandToExecute)
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _viewModel = new LogInfoWindowViewModel(commandToExecute)
            {
                Owner = this
            };
            DataContext = _viewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
