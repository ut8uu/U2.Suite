using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using U2.Library.ViewModels;

namespace U2.Library.Views
{
    public partial class Rigs : UserControl
    {
        public Rigs()
        {
            InitializeComponent();
            var viewModel = new RigsViewModel();
            this.DataContext = viewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
