using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using U2.Library.ViewModels;

namespace U2.Library.Views
{
    public partial class Rigs : UserControl
    {
        private RigsViewModel _viewModel;

        public Rigs()
        {
            InitializeComponent();
            _viewModel = new RigsViewModel();
            this.DataContext = _viewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
