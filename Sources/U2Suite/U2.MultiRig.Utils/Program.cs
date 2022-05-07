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

using System.Text;
using DynamicData;
using log4net;
using U2.Core;
using U2.MultiRig;
using U2.MultiRig.Code;
using U2.MultiRig.Utils;

ConsoleKey startKey = ConsoleKey.D1;

List<ConsoleManagementElement> mainMenu
    = new List<ConsoleManagementElement>
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
        new()
        {
            Function = TestUdpClient,
            Key = startKey++,
            Title = "Test UDP client",
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

    var rig = GetIC705Rig(parameters);
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

    Console.WriteLine("Polling the Icom IC-705");
    Console.Write("Select the COM port the device is connected to.");

    var rig = GetIC705Rig(parameters);
    rig.Start();

    Console.WriteLine("Press Enter to continue.");
    Console.ReadLine();

    rig.Dispose();

    return true;
}

static Rig GetIC705Rig(object[] parameters)
{
    var key = (ConsoleKey)parameters[0];
    var ports = ComPortHelper.EnumerateComPorts();
    var index = key - ConsoleKey.D1;
    var settings = new RigSettings
    {
        Port = ports.ElementAt(index).Name,
        BaudRate = Data.BaudRates.IndexOf(57600),
        DataBits = Data.DataBits.IndexOf(8),
        Parity = (int)Data.Parity.None,
        StopBits = Data.StopBits.IndexOf(1m),
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
    var rig = new Rig(1, settings, rigCommands);
    rig.RigParameterChanged += (sender, number, parameter, value) =>
    {
        Console.WriteLine($"RIG{number}: {parameter}={value}");
    };

    return rig;
}

static bool TestUdpClient(object[] parameters)
{
    var tokenSource = new CancellationTokenSource();
    var client = new UdpClient(CancellationToken.None);
    client.MessageReceived += ClientOnMessageReceived;
    client.Start();

    var server = new UdpServer(CancellationToken.None);
    server.Start();

    server.ComNotifySingleParameter(1, RigParameter.FreqA, 14100123);
    
    Console.WriteLine("Press x to finish.");

    while (true)
    {
        var key = Console.Read();
        if (key == 'x')
        {
            break;
        }
    }

    client.Stop();
    server.Stop();
    return true;
}

static void ClientOnMessageReceived(object sender, string message)
{
    if (string.IsNullOrEmpty(message) || !message.StartsWith("MR", StringComparison.InvariantCultureIgnoreCase))
    {
        Console.WriteLine($"Received unknown UDP message: {message}");
        return;
    }

    var chunks = message.Split('|', StringSplitOptions.RemoveEmptyEntries);
    if (chunks.Length != 5)
    {
        Console.WriteLine($"Received invalid UDP message: {message}. Expected chunks: 5.");
        return;
    }

    var rigNumber = int.Parse(chunks[1]);
    var key = chunks[2];
    var param1 = chunks[3];
    var param2 = chunks[4];

    switch (key)
    {
        case UdpMessageType.Parameter:
            ReportParameter(rigNumber, param1, param2);
            break;
        default:
            Console.WriteLine($@"{key} not recognized.");
            break;
    }
}

static void ReportParameter(int rigNumber, string paramId, string value)
{
    var id = Convert.ToInt32(paramId);
    var param = (RigParameter) id;
    Console.WriteLine($@"{param}: {value}");
}
