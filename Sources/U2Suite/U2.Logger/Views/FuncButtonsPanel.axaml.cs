using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Logger
{
    [PropertyChanged.DoNotNotify]
    public partial class FuncButtonsPanel : UserControl
    {
        private Window _owner;
        private readonly FuncButtonsPanelViewModel _viewModel;

        public FuncButtonsPanel()
        {
            InitializeComponent();

            _viewModel = new FuncButtonsPanelViewModel();
            DataContext = _viewModel;
        }

        public Window Owner
        {
            get => _owner;
            set
            {
                _owner = value;
                _viewModel.Owner = value;
            }
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
