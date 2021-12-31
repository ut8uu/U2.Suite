using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Core
{
    public partial class LicenseForm : Window
    {
        public LicenseForm()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
