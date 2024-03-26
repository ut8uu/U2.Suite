using System.Data;
using U2.Suite.Brandmeister.Contracts;
using U2.Suite.Brandmeister.Core;

namespace U2.Suite.Brandmeister.Win.UserControls;

public partial class BrandmeisterReports : UserControl
{
    BrandmeisterListener _listener;
    readonly Queue<SessionData> queue = new();
    int _totalReceived;
    System.Threading.Timer _updateItemsTimer;

    public BrandmeisterReports()
    {
        InitializeComponent();

        _listener = new BrandmeisterListener();
        _listener.Connected += Listener_Connected;
        _listener.Disconnected += Listener_Disconnected;
        _listener.SessionDataReceived += Listener_SessionDataReceived;
        _listener.MessageThrown += Listener_MessageThrown;

        _updateItemsTimer = new System.Threading.Timer(state => { OnTimerTick(); }, null,
            dueTime: 1000, period: 5000);

    }

    public int MaxDisplayedReports { get; set; } = 100;

    public Action? OnNewReport { get; set; }
    public Action<string>? OnNewCall { get; set; }
    public Action<int>? OnNewTalkGroup { get; set; }
    public Action<string>? OnStatusChanged { get; set; }

    #region Event Handlers

    private void OnTimerTick()
    {
        ProcessReports();
    }

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
        AddReport(data);

        OnNewReport?.Invoke();
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

    private void btnFilter_Click(object sender, EventArgs e)
    {

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

    internal static bool CanBeDisplayed(SessionData data)
    {
        if (data == null)
        {
            return false;
        }

        if (data.Stop == 0 || (data.Stop - data.Start) < 5)
        {
            return false;
        }

        if (ReportsFilter.IsFiltered(data.SourceCall!, FilterTarget.Call))
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

    public void AddReport(SessionData data)
    {
        if (CanBeDisplayed(data))
        {
            queue.Enqueue(data);
        }
    }

    public void ProcessReports()
    {
        Invoke(() =>
        {
            lvReports.BeginUpdate();

            while (queue.TryDequeue(out var data))
            {
                var rdd = ReportDisplayData.FromSessionData(data);

                var reports = new List<ReportDisplayData>();

                foreach (ListViewItem item in lvReports.Items)
                {
                    if (item.Tag is ReportDisplayData report && report != null)
                    {
                        reports.Add(report);
                    }
                }

                if (IsReportDisplayed(reports, rdd, out var displayIndex))
                {
                    lvReports.Items[displayIndex].SubItems[3].Text = rdd.Duration.ToString();
                }
                else
                {
                    var newItem = new ListViewItem(rdd.DateTime.ToString());
                    newItem.SubItems.Add(rdd.CallString);
                    newItem.SubItems.Add(rdd.TalkGroupString);
                    newItem.SubItems.Add(rdd.Duration.ToString());
                    newItem.Tag = rdd;

                    lvReports.Items.Insert(displayIndex, newItem);
                }

                while (lvReports.Items.Count > MaxDisplayedReports)
                {
                    lvReports.Items.RemoveAt(lvReports.Items.Count - 1);
                }
            }

            lvReports.EndUpdate();
        });
    }

    public bool IsReportDisplayed(List<ReportDisplayData> reports, ReportDisplayData reportDisplayData, out int displayIndex)
    {
        displayIndex = 0;

        var allDates = reports.Select(x => x.DateTime).ToList();
        displayIndex = allDates.BinarySearch(reportDisplayData.DateTime,
            Comparer<DateTime>.Create((x, y) => y.CompareTo(x)));

        var existingReport = reports.FirstOrDefault(r => r.Call == reportDisplayData.Call &&
            r.TG == reportDisplayData.TG &&
            r.DateTime == reportDisplayData.DateTime);

        if (existingReport != null)
        {
            return true;
        }

        if (displayIndex < 0)
        {
            displayIndex = ~displayIndex;
        }
        return false;
    }
}
