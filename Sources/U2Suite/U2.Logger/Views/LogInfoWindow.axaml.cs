using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using GalaSoft.MvvmLight.Messaging;
using U2.Logger.Models;

namespace U2.Logger
{
    [PropertyChanged.DoNotNotify]
    public partial class LogInfoWindow : Window
    {
        LogInfoWindowViewModel _viewModel;

        public LogInfoWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _viewModel = new LogInfoWindowViewModel();
            _viewModel.Owner = this;
            DataContext = _viewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void CreateNewLog()
        {
            var logInfo = new LogInfo
            {
                LogName = _viewModel.LogName,
                Description = _viewModel.Description,
            };
            var message = new ExecuteCommandMessage(CommandToExecute.CreateLog, logInfo);
            Messenger.Default.Send(message);

            AppSettings.Default.LogName = _viewModel.LogName;
            AppSettings.Default.Save();
            Close();
        }

        public void CloseWindow()
        {
            Close();
        }
    }
}
