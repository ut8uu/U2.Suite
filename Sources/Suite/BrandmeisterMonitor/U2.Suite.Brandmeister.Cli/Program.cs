// See https://aka.ms/new-console-template for more information
using U2.Suite.Brandmeister.Contracts;
using U2.Suite.Brandmeister.Core;

Console.WriteLine("Hello, World!");

var listener = new BrandmeisterListener();
listener.Connected += Listener_Connected;
listener.Disconnected += Listener_Disconnected;
listener.SessionDataReceived += Listener_SessionDataReceived;
listener.MessageThrown += Listener_MessageThrown;

listener.Start();

Console.WriteLine("Press Enter to finish.");
Console.ReadLine();

listener.Stop();
listener.Dispose();

void Listener_MessageThrown(object sender, string message)
{
    Console.WriteLine(message);
}

void Listener_SessionDataReceived(object sender, SessionData data)
{
    Console.WriteLine($"{data.SessionID} {data.Start} {data.SourceCall} @ TG:{data.DestinationID}");
}

void Listener_Disconnected(object sender)
{
    Console.WriteLine("Disconnected");
}

void Listener_Connected(object sender)
{
    Console.WriteLine("Connected");
}