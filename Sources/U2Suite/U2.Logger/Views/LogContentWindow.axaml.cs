using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Logger
{
    [PropertyChanged.DoNotNotify]
    public partial class LogContentWindow : Window
    {
        private LogContentWindowViewModel _viewModel = default!;

        private DataGrid _mainGrid;

        public LogContentWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _viewModel = new LogContentWindowViewModel();
            _viewModel.Owner = this;
            DataContext = _viewModel;

            _mainGrid = (DataGrid)this.Find<DataGrid>("MainGrid");
            _mainGrid.SelectionChanged += _mainGrid_SelectionChanged;
        }

        private void _mainGrid_SelectionChanged(object? sender, 
            SelectionChangedEventArgs e)
        {
            _viewModel.SelectItems(e.AddedItems as List<object>);
            _viewModel.DeselectItems(e.RemovedItems as List<LogRecordDbo>);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
