using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Logger
{
    [PropertyChanged.DoNotNotify]
    public partial class QsoEditorWindow : Window
    {
        private readonly QsoEditorViewModel _qsoEditorVM;

        public QsoEditorWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            _qsoEditorVM = new QsoEditorViewModel(new LogRecordDbo());
            DataContext = _qsoEditorVM;
        }

        public QsoEditorWindow(LogRecordDbo record)
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            _qsoEditorVM = new QsoEditorViewModel(record);
            DataContext = _qsoEditorVM;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
