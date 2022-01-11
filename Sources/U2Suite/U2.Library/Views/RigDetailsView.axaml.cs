using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using U2.Library.Database.Models;
using U2.Library.ViewModels;

namespace U2.Library.Views
{
    public partial class RigDetailsView : UserControl
    {
        private RigDbo selectedRig;
        private RigDetailsViewModel _viewModel;

        public RigDetailsView()
        {
            InitializeComponent();

            _viewModel = new RigDetailsViewModel();
            this.DataContext = _viewModel;
        }

        public RigDbo SelectedRig
        {
            get => selectedRig;
            set
            {
                selectedRig = value;
                _viewModel.Rig = value;
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
