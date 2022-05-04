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
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.ObjectModel;

namespace U2.MultiRig;

public enum CommandKind
{
    Init, Write, Status, Custom
}

public enum ExchangePhase
{
    Sending, Receiving, Idle
}

public sealed class QueueItem
{
    public byte[]? Code { get; set; }
    public CommandKind Kind { get; set; }
    public RigParameter Param { get; set; } = new RigParameter();
    public int Number { get; set; } = 0;
    public object CustSender { get; set; } = new object();
    public int ReplyLength { get; set; } = 0;
    public string ReplyEnd { get; set; } = string.Empty;

    public bool NeedsReply => ReplyLength > 0 || ReplyEnd != string.Empty;
}


public sealed class CommandQueue : Collection<QueueItem>
{
    public ExchangePhase Phase;

    public QueueItem Add()
    {
        var item = new QueueItem();
        Add(item);
        return item;
    }

    public void AddBeforeStatusCommands(QueueItem item)
    {
        var firstStatusItem = Items.FirstOrDefault(x => x.Kind == CommandKind.Status);
        if (firstStatusItem == null)
        {
            Add(item);
            return;
        }

        var index = Items.IndexOf(firstStatusItem);
        if (index == 0 && Items.Count > 1)
        {
            // status command is the first in the list and cannot be replaced
            // therefore, the new element should be inserted after it
            index++;
        }
        Items.Insert(index, item);
    }

    public bool HasStatusCommands
    {
        get { return Items.Any(x => x.Kind == CommandKind.Status); }
    }

    public QueueItem? CurrentCmd => Items.FirstOrDefault();
}
