using System.Text;
using DynamicData;
using U2.MultiRig;

List<ConsoleManagementElement> mainMenu
    = new List<ConsoleManagementElement>
    {
        new ConsoleManagementElement
        {
            Function = PollIcom705,
            Key = ConsoleKey.D1,
            Title = "Poll Icom IC-705",
        },
    };

ManageFlow(mainMenu);

static bool PollIcom705()
{
    var settings = new RigSettings
    {
        Port = "COM10",
        BaudRate = 9600,
        DataBits = U2.MultiRig.Code.Data.DataBits.IndexOf(8),
        Parity = (int)U2.MultiRig.Code.Data.Parity.None,
        StopBits = (int)U2.MultiRig.Code.Data.StopBits.IndexOf(1m),
        
    };

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

                func.Function();

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
public sealed class ConsoleManagementElement
{
    public ConsoleKey Key { get; init; }
    public string? Title { get; init; }
    public Func<bool>? Function { get; init; }
}