using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.CommonControls
{
    [PropertyChanged.DoNotNotify]
    public partial class OkCancelButtonsUserControl : UserControl
    {
        public OkCancelButtonsUserControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
