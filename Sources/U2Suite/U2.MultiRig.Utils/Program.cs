using System.Text;
using DynamicData;
using log4net;
using U2.Core;
using U2.MultiRig;

List<ConsoleManagementElement> mainMenu
    = new List<ConsoleManagementElement>
    {
        new()
        {
            Function = PollIcom705,
            Key = ConsoleKey.D1,
            Title = "Poll Icom IC-705",
        },
    };

ManageFlow(mainMenu);

static void Log(string message)
{
    LogManager.GetLogger(typeof(Program)).Info(message);
}

static bool PollIcom705(object[] parameters)
{
    var ports = ComPortHelper.EnumerateComPorts();
    var menu = new List<ConsoleManagementElement>();
    var key = ConsoleKey.D1;
    foreach (var port in ports)
    {
        menu.Add(new()
        {
            Function = PollIcom705Port,
            FunctionParameters = new object[]{ key },
            Key = key,
            Title = port.Description,
        });
        key++;
    }

    ManageFlow(menu);

    return true;
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

    var key = (ConsoleKey)parameters[0];
    var ports = ComPortHelper.EnumerateComPorts();
    var index = key - ConsoleKey.D1;
    var settings = new RigSettings
    {
        Port = ports.ElementAt(index).Name,
        BaudRate = 57600,
        DataBits = 8,
        Parity = (int)U2.MultiRig.Code.Data.Parity.None,
        StopBits = (int)U2.MultiRig.Code.Data.StopBits.IndexOf(1m),
        Enabled = true,
    };

    var rigCommands = AllRigCommands.RigCommands
        .FirstOrDefault(c => c.RigType == "IC-705");
    if (rigCommands == null)
    {
        Log("Commands for IC-705 not found.");
        return true;
    }

    var rig = new Rig(1, settings, rigCommands);
    rig.Connect();

    Console.WriteLine("Press Enter to continue.");
    Console.ReadLine();

    rig.Dispose();

    return true;
}
