using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PropertyChanged;

namespace U2.MultiRig.Views
{
    [DoNotNotify]
    public partial class RigSettingsView : UserControl
    {
        private RigSettingsViewModel _model;

        public RigSettingsView()
        {
            InitializeComponent();

            _model = new RigSettingsViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
