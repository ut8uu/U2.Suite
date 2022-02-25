using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using GalaSoft.MvvmLight.Messaging;
using U2.Logger.Models;

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
            _viewModel = new LogInfoWindowViewModel(CommandToExecute.CreateLog);
            _viewModel.Owner = this;
            DataContext = _viewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
