using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Logger
{
    [PropertyChanged.DoNotNotify]
    public partial class TextInputPanel : UserControl
    {
        private Window _owner = default!;
        private readonly TextInputPanelViewModel _viewModel;

        public TextInputPanel()
        {
            InitializeComponent();

            _viewModel = new TextInputPanelViewModel();
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
