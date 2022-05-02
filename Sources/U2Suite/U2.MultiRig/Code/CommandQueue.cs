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
    public byte[] Code { get; set; }
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
        }
        else
        {
            var index = Items.IndexOf(firstStatusItem);
            if (index == 0)
            {
                if (Items.Count > 1)
                {
                    index++;
                }
            }
            Items.Insert(index, item);
        }
    }

    public bool HasStatusCommands
    {
        get { return Items.Any(x => x.Kind == CommandKind.Status); }
    }

    public QueueItem? CurrentCmd => Items.FirstOrDefault();
}
