using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Logger
{
    [PropertyChanged.DoNotNotify]
    public partial class LogContentWindow : Window
    {
        private LogContentWindowViewModel _viewModel = default!;
        private LoggerDbContext _dbContext = default!;

        public LogContentWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _dbContext = new LoggerDbContext();
            _viewModel = new LogContentWindowViewModel(_dbContext);
            _viewModel.Owner = this;
            DataContext = _viewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
