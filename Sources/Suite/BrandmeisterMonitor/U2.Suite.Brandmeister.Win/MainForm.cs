using U2.Suite.Brandmeister.Contracts;
using U2.Suite.Brandmeister.Core;

namespace U2.Suite.Brandmeister.Win;

public partial class MainForm : Form
{

    public MainForm()
    {
        InitializeComponent();

        ucReports.OnNewReport = ReportAdded;
        ucReports.OnNewCall = OnNewCall;
        ucReports.OnNewTalkGroup = OnNewTalkGroup;
        ucReports.OnStatusChanged = OnStatusChanged;
    }

    private void OnStatusChanged(string status)
    {
        ucStatusBar.SetStatus(status);
    }

    private void OnNewTalkGroup(int tg)
    {
        //BmTalkGroups.AddTalkGroup(data.DestinationID);
    }

    private void OnNewCall(string call)
    {
        //BmUniqueCalls.AddCall(data.SourceCall);
    }

    private void ReportAdded()
    {
        ucStatusBar.IncreaseCounter();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        ucReports.StartListening();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        ucReports.StopListening();
    }
}
