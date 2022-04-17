using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using U2.MultiRig.Views;

namespace U2.MultiRig
{
    [PropertyChanged.DoNotNotify]
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var window = new MultiRigWindow();
                desktop.MainWindow = window;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
