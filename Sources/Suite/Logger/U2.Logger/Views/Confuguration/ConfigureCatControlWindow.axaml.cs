using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Logger;

[PropertyChanged.DoNotNotify]
public partial class ConfigureCatControlWindow : Window
{
    public ConfigureCatControlWindow()
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
