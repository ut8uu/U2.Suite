using System.Reactive;
using ReactiveUI;
using U2.Core;
using U2.Resources;

namespace U2.Suite
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly MainWindow _window;

        public string Greeting => "Welcome to Avalonia!";
        public string QslManagerTitle => "QSL Manager";

        public ReactiveCommand<Unit, Unit> LaunchQslManagerCommand { get; }

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(MainWindow window)
        {
            LaunchQslManagerCommand = ReactiveCommand.Create(LaunchQslManager);
            this._window = window;
        }

        private void LaunchQslManager()
        {
            Launcher.Launch(ApplicationNames.GetQslManagerAppName(), string.Empty);
        }

        public void ShowAboutWindow()
        {
            var window = new AboutFormView();
            window.ShowDialog(_window);
        }

        public void ShowLicenseWindow()
        {
            var window = new LicenseFormView();
            window.ShowDialog(_window);
        }

        public void ShowContributorsWindow()
        {
            var window = new ContributorsWindow();
            window.ShowDialog(_window);
        }

        public void LaunchLibrary()
        {
            Launcher.Launch(ApplicationNames.GetLibraryAppName(), string.Empty);
        }
    }
}
