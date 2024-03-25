using System.Reflection;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace U2.Suite.Helpers;

public static class FileSystemHelper
{
    public const string U2SuiteStorageFolder = "U2.Suite";

    private static JsonSerializerSettings DefaultSettings = new()
    {
        Formatting = Formatting.Indented,
    };
    public static string LocalFolder => Path.GetDirectoryName(path: Assembly.GetExecutingAssembly().Location);
    public static string SuiteDataFolder
    {
        get
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(appDataPath, U2SuiteStorageFolder);
        }
    }
    public static string BrandmeisterStorageDataFolder => Path.Combine(SuiteDataFolder, "Brandmeister");

    public static void EnsureDirectory(string directory)
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }

    public static string ChildFolder(string child)
    {
        return Path.Combine(LocalFolder, child);
    }

    public static T? ReadFromFile<T>(string path)
    {
        if (!File.Exists(path))
        {
            return default(T);
        }
        var content = File.ReadAllText(path);
        var result = JsonConvert.DeserializeObject<T>(content);
        return result;
    }

    public static void SaveToFile(string path, object obj)
    {
        var s = JsonConvert.SerializeObject(obj, DefaultSettings);
        File.WriteAllText(path, s);
    }
}
