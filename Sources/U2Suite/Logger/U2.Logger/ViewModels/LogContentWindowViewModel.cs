/* 
 * This file is part of the U2.Suite distribution
 * (https://github.com/ut8uu/U2.Suite).
 * 
 * Copyright (c) 2022 Sergey Usmanov, UT8UU.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using U2.Common;

namespace U2.Logger;

public class LogContentViewModel : ViewModelBase
{
    public LogContentViewModel()
    {
        try
        {
            FullList = new ObservableCollection<LogRecordDbo>(LoggerDbContext.Instance.Records);

            Messenger.Default.Register<ExecuteCommandMessage>(this,
                AcceptExecuteCommandMessage);
        }
        catch
        {

        }
    }

    public Window? Owner { get; set; }

    public string CloseButtonText { get; set; } = Resources.CloseButtonTitle;
    public string EditButtonText { get; set; } = Resources.EditButtonTitle;
    public string DeleteButtonText { get; set; } = Resources.DeleteButtonTitle;

    public string CallsignColumnHeader { get; set; } = Resources.Callsign;
    public string TimestampColumnHeader { get; set; } = Resources.Timestamp;
    public string BandColumnHeader { get; set; } = Resources.BandColumnHeader;
    public string ModeColumnHeader { get; set; } = Resources.Mode;
    public string RstSentColumnHeader { get; set; } = Resources.Snt;
    public string RstReceivedColumnHeader { get; set; } = Resources.Rcv;
    public string NameColumnHeader { get; set; } = Resources.Operator;
    public string CommentsColumnHeader { get; set; } = Resources.Comments;

    public ObservableCollection<LogRecordDbo> FullList { get; set; } = default!;
    public ObservableCollection<LogRecordDbo> FilteredList { get; set; } = default!;

    public LogRecordDbo SelectedRecord { get; set; } = default!;
    public List<LogRecordDbo> SelectedItems = new List<LogRecordDbo>();

    private void AcceptExecuteCommandMessage(ExecuteCommandMessage message)
    {
        if (message.CommandToExecute == CommandToExecute.RefreshLog)
        {
            RefreshLog();
        }
    }

    public void RefreshLog()
    {
        LoggerDbContext.Reset();
        FullList = new ObservableCollection<LogRecordDbo>(LoggerDbContext.Instance.Records);
    }

    public void CloseButtonClick()
    {
        Owner.Close();
    }

    public void EditButtonClick()
    {
        if (SelectedRecord == null)
        {
            return;
        }

        var editor = new QsoEditorWindow(SelectedRecord);
        editor.ShowDialog(Owner);
    }

    public void SelectItems(List<object> selectedItems)
    {
        if (selectedItems == null)
        {
            return;
        }
        SelectedItems.AddRange(selectedItems.Cast<LogRecordDbo>().Except(SelectedItems));
    }

    public void DeselectItems(IEnumerable<LogRecordDbo> deselectedItems)
    {
        if (deselectedItems == null)
        {
            return;
        }
        SelectedItems = SelectedItems.Except(deselectedItems).ToList();
    }

    /// <summary>
    /// Emits a commend for QSO deletion.
    /// Sends identifiers of all the selected records, if any.
    /// </summary>
    public void DeleteButtonClick()
    {
        if (!SelectedItems.Any())
        {
            return;
        }

        var message = new ExecuteCommandMessage(CommandToExecute.DeleteQso, 
            SelectedItems.Select(i => i.RecordId).ToArray());
        Messenger.Default.Send(message);
        SelectedItems = new List<LogRecordDbo>();
    }
}

public sealed class DemoLogContentViewModel : LogContentViewModel
{
    public DemoLogContentViewModel()
    {
        FullList = new ObservableCollection<LogRecordDbo>
        {
            GetRandomRecord(),
            GetRandomRecord(),
            GetRandomRecord(),
        };
    }

    private LogRecordDbo GetRandomRecord()
    {
        return new LogRecordDbo
        {
            Callsign = $"UT{DateTime.UtcNow.Millisecond}UU",
            Band = "80m",
            Mode = "CW",
            QsoEndTimestamp = DateTime.UtcNow,
            Frequency = 3.5m,
            RecordId = Guid.NewGuid(),
            Comments = "",
            Operator = "UT8UU",
            RstReceived = "599",
            RstSent = "599",
        };
    }
}
