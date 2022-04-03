using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Logger
{
    [PropertyChanged.DoNotNotify]
    public partial class LogInfoDetailsUserControl : UserControl
    {
        private LogInfoWindowViewModel _model;

        public LogInfoDetailsUserControl()
        {
            InitializeComponent();

            _model = new LogInfoWindowViewModel(CommandToExecute.OpenLog)
            {
                WindowTitle = U2.Logger.Resources.LogInfoDetailsHeader
            };
            this.DataContext = _model;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void ShowLogInfo(LogInfo logInfo)
        {
            _model.SetLogInfo(logInfo);
        }

        public string HeaderText { get; set; } = "aa";
    }
}
