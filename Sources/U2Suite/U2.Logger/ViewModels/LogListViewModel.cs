using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace U2.Logger;

public class LogListViewModel : ViewModelBase
{
    private Window? _owner;
    private LogInfo? selectedItem;
    private LogInfoDetailsUserControl? _detailsViewer;

    public LogListViewModel(string directory)
    {
        List = LoadLogs(directory);
    }

    public string CancelButtonTitle { get; set; } = Resources.Cancel;
    public string OkButtonTitle { get; set; } = Resources.OK;

    public Window? Owner
    {
        get => _owner;
        set
        {
            _owner = value;
            _detailsViewer = _owner.FindControl<LogInfoDetailsUserControl>("LogInfoDetailsViewer");
        }
    }
    public ObservableCollection<LogInfo> List { get; init; }

    public LogInfo? SelectedItem {
        get => selectedItem;
        set 
        {
            selectedItem = value;
            _detailsViewer?.ShowLogInfo(value);
        }
    }

    private static ObservableCollection<LogInfo> LoadLogs(string logDirectory)
    {
        var result = new ObservableCollection<LogInfo>();

        Directory.CreateDirectory(logDirectory);

        var sqliteFiles = Directory.EnumerateFiles(logDirectory, $"*.json");
        foreach (var file in sqliteFiles)
        {
            using var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Delete);
            var logInfoFile = JsonSerializer.Deserialize<LogInfo>(stream);
            if (logInfoFile == null)
            {
                continue;
            }
            result.Add(logInfoFile);
        }

        return result;
    }

    public void ExecuteOkAction()
    {
        if (SelectedItem == null)
        {
            return;
        }

        AppSettings.Default.LogName = SelectedItem.LogName;
        var message = new ExecuteCommandMessage(CommandToExecute.SwitchLog);
        Messenger.Default.Send(message);

        Owner?.Close();
    }

    public void ExecuteCancelAction()
    {
        SelectedItem = null;
        Owner?.Close();
    }
}

public sealed class DemoLogListViewModel : LogListViewModel
{
    public DemoLogListViewModel() :
        base(Path.GetTempPath())
    {
        List = new ObservableCollection<LogInfo> {
            new LogInfo
            {
                LogName = "log 001",
                Description = "description 001"
            },
            new LogInfo
            {
                LogName = "log 002",
                Description = "description 002"
            },
            new LogInfo
            {
                LogName = "log 003",
                Description = "description 003"
            },
        };
    }
}
