using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.CommonControls.Views
{
    public partial class DialogWindowBase : Window
    {
        public DialogWindowBase()
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
