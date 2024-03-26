using U2.Suite.Brandmeister.Contracts;
using U2.Suite.Brandmeister.Core;

namespace U2.Suite.Brandmeister.Core.Tests;

public class BrandmeisterListenerTests
{
    [Fact]
    public void Test1()
    {
        var listener = new BrandmeisterListener();
        listener.SessionDataReceived += Listener_DataReceived;
        listener.Start();

        while (true)
        {
            Thread.Sleep(100);
        }
    }

    private void Listener_DataReceived(object sender, SessionData data)
    {
        Console.WriteLine(data.SourceCall);
    }
}