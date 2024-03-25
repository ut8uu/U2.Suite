using U2.Suite.Brandmeister.Contracts;
using U2.Suite.Brandmeister.Core;

namespace U2.Suite.Brandmeister.Win;

public partial class MainForm : Form
{
    BrandmeisterListener _listener;

    public MainForm()
    {
        InitializeComponent();

        _listener = new BrandmeisterListener();
        _listener.Connected += Listener_Connected;
        _listener.Disconnected += Listener_Disconnected;
        _listener.SessionDataReceived += Listener_SessionDataReceived;
        _listener.MessageThrown += Listener_MessageThrown;
    }

    private void Listener_MessageThrown(object sender, string message)
    {
        throw new NotImplementedException();
    }

    private void Listener_SessionDataReceived(object sender, SessionData data)
    {
        throw new NotImplementedException();
    }

    private void Listener_Disconnected(object sender)
    {
        throw new NotImplementedException();
    }

    private void Listener_Connected(object sender)
    {
        throw new NotImplementedException();
    }
}
