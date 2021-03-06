using System.IO;
using System.Reflection;

namespace AvaloniaEdit.Editor.Resources
{
    internal static class ResourceLoader
    {
        const string SampleFilesPrefix = "AvaloniaEdit.Demo.Resources.SampleFiles.";

        internal static string LoadSampleFile(string fileName)
        {
            Stream stream = typeof(ResourceLoader).GetTypeInfo().Assembly.GetManifestResourceStream(SampleFilesPrefix + fileName);

            if (stream == null)
                return string.Empty;

            using (stream)
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}