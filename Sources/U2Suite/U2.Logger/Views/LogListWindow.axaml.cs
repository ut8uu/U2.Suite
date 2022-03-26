using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using U2.Core;

namespace U2.Logger.Views
{
    [PropertyChanged.DoNotNotify]
    public partial class LogListWindow : Window
    {
        LogListViewModel _model;

        public LogListWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            var logsDirectory = FileSystemHelper.GetDatabaseFolderPath(U2.Resources.ApplicationNames.LibraryOsx);
            
            _model = new LogListViewModel(LoadLogs(logsDirectory));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        internal static LogList LoadLogs(string logDirectory)
        {
            var result = new LogList();

            var sqliteFiles = Directory.EnumerateFiles($"*{CommonConstants.DatabaseExtension}");
            foreach (var file in sqliteFiles)
            {
                //var logInfoFile = 
            }

            return result;
        }
    }
}
