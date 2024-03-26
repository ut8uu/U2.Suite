using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using U2.Suite.Brandmeister.Contracts;
using U2.Suite.Brandmeister.Core;

namespace U2.Suite.Brandmeister.Win.UserControls;

public partial class BrandmeisterReports : UserControl
{
    BrandmeisterListener _listener;
    private int _totalReceived;
    readonly Queue<SessionData> _queue = new();

    public BrandmeisterReports()
    {
        InitializeComponent();

        _listener = new BrandmeisterListener();
        _listener.Connected += Listener_Connected;
        _listener.Disconnected += Listener_Disconnected;
        _listener.SessionDataReceived += Listener_SessionDataReceived;
        _listener.MessageThrown += Listener_MessageThrown;
    }

    public Action? OnNewReport { get; set; }
    public Action<string>? OnNewCall { get; set; }
    public Action<int>? OnNewTalkGroup { get; set; }
    public Action<string>? OnStatusChanged { get; set; }

    #region Event Handlers

    private void Listener_MessageThrown(object sender, string message)
    {
        throw new NotImplementedException();
    }

    private void Listener_SessionDataReceived(object sender, SessionData data)
    {
        if (string.IsNullOrEmpty(data.SourceCall))
        {
            return;
        }
        _totalReceived++;
        OnNewReport?.Invoke();
        AddReport(data);

        OnNewCall?.Invoke(data.SourceCall);
        OnNewTalkGroup?.Invoke(data.DestinationID);
    }

    private void Listener_Disconnected(object sender)
    {
        OnStatusChanged?.Invoke("Disconnected");
    }

    private void Listener_Connected(object sender)
    {
        OnStatusChanged?.Invoke("Connected");
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        StartListening();
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
        StopListening();
    }

    #endregion

    public void StartListening()
    {
        _listener.Start();
    }

    public void StopListening()
    {
        _listener.Stop();
    }

    public void AddReport(SessionData data)
    {
        if (CanBeDisplayed(data))
        {
            _queue.Enqueue(data);
        }
    }

    internal static bool CanBeDisplayed(SessionData data)
    {
        if (data.Stop == 0 || (data.Stop - data.Start) < 5)
        {
            return false;
        }

        if (ReportsFilter.IsFiltered(data.SourceCall, FilterTarget.Call))
        {
            return true;
        }

        if (ReportsFilter.IsFiltered(data.Dxcc.ToString(), FilterTarget.Dxcc))
        {
            return true;
        }

        if (ReportsFilter.IsFiltered(data.DestinationID.ToString(), FilterTarget.TalkGroup))
        {
            return true;
        }

        return false;
    }
}
