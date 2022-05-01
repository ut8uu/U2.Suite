using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace U2.MultiRig;

public enum TCommandKind
{
    ckInit, ckWrite, ckStatus, ckCustom
}

public enum TExchangePhase
{
    phSending, phReceiving, phIdle
}

public partial class TQueueItem
{
    public byte[] Code;
    public TCommandKind Kind;
    public RigParameter Param = new RigParameter();
    public int Number = 0;
    public object CustSender = new object();
    public int ReplyLength = 0;
    public string ReplyEnd = string.Empty;

    public bool NeedsReply => ReplyLength > 0 || ReplyEnd != string.Empty;
}


public partial class TCommandQueue : Collection<TQueueItem>
{
    public TExchangePhase Phase;
    
    public TQueueItem Add()
    {
        var item = new TQueueItem();
        Add(item);
        return item;
    }

    public void AddBeforeStatusCommands(TQueueItem item)
    {
        var firstStatusItem = Items.FirstOrDefault(x => x.Kind == TCommandKind.ckStatus);
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
        get { return Items.Any(x => x.Kind == TCommandKind.ckStatus); }
    }

    public TQueueItem CurrentCmd => Items[0];
}
