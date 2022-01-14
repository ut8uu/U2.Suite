using Avalonia.Controls;

namespace U2.Logger
{
    public class LoggerMainWindowViewModel : ViewModelBase
    {
        public LoggerMainWindowViewModel()
        {

        }

        public LoggerMainWindowViewModel(Window owner)
        {
            Owner = owner;
        }

        public Window Owner { get; } = default!;
        public string StatusText { get; set; } = default!;

    }
}
