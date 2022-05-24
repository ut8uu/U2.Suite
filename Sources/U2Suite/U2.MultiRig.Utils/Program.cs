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

using System.Net;
using System.Net.Sockets;
using System.Reactive.Joins;
using System.Text;
using DynamicData;
using log4net;
using SimpleUdp;
using U2.Core;
using U2.MultiRig;
using U2.MultiRig.Code;
using U2.MultiRig.Code.UDP;
using U2.MultiRig.Utils;

var startKey = ConsoleKey.D1;

var mainMenu = new List<ConsoleManagementElement>
{
    new()
    {
        Function = PollIcom705,
        Key = startKey++,
        Title = "Poll Icom IC-705",
    },
    new()
    {
        Function = ManageIcom705,
        Key = startKey++,
        Title = "Manage Icom IC-705",
    },
};

ManageFlow(mainMenu);

static void Log(string message)
{
    LogManager.GetLogger(typeof(Program)).Info(message);
}

static bool SelectComPort(Func<object[], bool> func)
{
    var ports = ComPortHelper.EnumerateComPorts();
    var menu = new List<ConsoleManagementElement>();
    var key = ConsoleKey.D1;
    foreach (var port in ports)
    {
        menu.Add(new()
        {
            Function = func,
            FunctionParameters = new object[] { key },
            Key = key,
            Title = port.Description,
        });
        key++;
    }

    ManageFlow(menu);

    return true;
}

static bool ManageIcom705(object[] parameters)
{
    return SelectComPort(ManageIcom705Port);
}

static bool ManageIcom705Port(params object[] parameters)
{
    Log("Entered PollIcom705()");

    Console.WriteLine("Polling the Icom IC-705");
    Console.Write("Select the COM port the device is connected to.");

    var rig = GetIC705HostRig(parameters);
    rig.Start();

    Console.WriteLine("Press any key to abort.");

    var i = 20;
    while (i > 0)
    {
        var newValue = 21100000 + i-- * 1000;
        Console.WriteLine($"Setting FreqA to {newValue}");
        rig.SetFreqA(newValue);
        Thread.Sleep(1000);

        if (Console.KeyAvailable)
        {
            break;
        }
    }

    Console.WriteLine("Press Enter to continue.");
    Console.ReadLine();

    return true;
}

static bool PollIcom705(object[] parameters)
{
    return SelectComPort(PollIcom705Port);
}

static void ManageFlow(List<ConsoleManagementElement> input)
{
    var output = new StringBuilder();
    foreach (var el in input)
    {
        output.Append($"{el.Key}. {el.Title}");
        output.AppendLine();
    }

    output.AppendLine();
    output.AppendLine("X. Exit");

    while (true)
    {
        Console.Clear();
        Console.WriteLine(output);

        var key = Console.ReadKey();
        if (input.Any(o => o.Key == key.Key))
        {
            var func = input.FirstOrDefault(o => o.Key == key.Key);
            if (func != null)
            {
                Console.Clear();
                Console.WriteLine(func.Title);
                Console.WriteLine("---------------------------------------");

                func.Function(func.FunctionParameters);

                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        else if (key.Key == ConsoleKey.X)
        {
            break;
        }
        else
        {
            Console.WriteLine("Unrecognized input");
            Console.WriteLine("");
        }
    }
}

static bool PollIcom705Port(params object[] parameters)
{
    Log("Entered PollIcom705()");

    Console.WriteLine(@"Polling the Icom IC-705");
    Console.Write(@"Select the COM port the device is connected to.");

    var rig = GetIC705HostRig(parameters);
    rig.Start();

    var guest = new GuestRig(1, KnownIdentifiers.U2Logger);
    guest.UdpPacketReceived += (sender, args) =>
    {
        Console.WriteLine($@"Received packet: {ByteFunctions.BytesToHex(args.Packet.GetBytes())}");
    };

    Console.WriteLine(@"Press Enter to continue.");
    Console.ReadLine();

    rig.Dispose();

    return true;
}

static Rig GetIC705GuestRig(object[] parameters)
{
    throw new NotImplementedException();
}

static Rig GetIC705HostRig(object[] parameters)
{
    var key = (ConsoleKey)parameters[0];
    var ports = ComPortHelper.EnumerateComPorts();
    var index = key - ConsoleKey.D1;
    var settings = new RigSettings
    {
        Port = ports.ElementAt(index).Name,
        BaudRate = ComPortStuff.BaudRates.IndexOf(57600),
        DataBits = ComPortStuff.DataBits.IndexOf(8),
        Parity = (int)ComPortStuff.Parity.None,
        StopBits = ComPortStuff.StopBits.IndexOf(1m),
        Enabled = true,
    };

    var rigCommands = AllRigCommands.RigCommands
        .FirstOrDefault(c => c.RigType == "IC-705");
    if (rigCommands == null)
    {
        Log("Commands for IC-705 not found.");
        throw new FileNotFoundException("INI file for IC-705 not found.");
    }

    settings.Enabled = true;
    var rig = new HostRig(1, KnownIdentifiers.U2MultiRig, settings, rigCommands);
    rig.RigParameterChanged += (sender, number, parameter, value) =>
    {
        ReportParameter(number, parameter, value.ToString());
    };

    return rig;
}

static void ReportParameter(int rigNumber, RigParameter paramId, string value)
{
    var id = Convert.ToInt32(paramId);
    var param = (RigParameter)id;
    Console.WriteLine($@"{param}: {value}");
}

static RigUdpMessengerPacket CreateNewPacket(byte messageId,
    ushort senderId, ushort receiverId, char messageType,
    ushort commandId, ushort dataLength, byte[] data)
{
    var result = new RigUdpMessengerPacket
    {
        MagicNumber = new MagicNumberPacketChunk(),
        Timestamp = new TimestampPacketChunk(DateTime.UtcNow),
        MessageId = new MessageIdPacketChunk(messageId),
        SenderId = new SenderIdPacketChunk(senderId),
        ReceiverId = new ReceiverIdPacketChunk(receiverId),
        MessageType = new MessageTypePacketChunk(messageType),
        Checksum = new ChecksumPacketChunk(0),
        CommandId = new CommandIdPacketChunk(commandId),
        DataLength = new DataLengthPacketChunk(dataLength),
        Data = DataPacketChunk.Create(data),
    };

    return result;
}

static void OnNewDataFromUdpServerArrived(object? sender, UdpDataReceivedEventArgs e)
{
    if (e.Data.Length == 0)
    {
        return;
    }
    var s = ByteFunctions.BytesToHex(e.Data);
    if (!string.IsNullOrEmpty(s))
    {
        var ep = (IPEndPoint)e.EndPoint;
        Console.WriteLine($"{ep.Address}:{ep.Port} {s}");
    }
}