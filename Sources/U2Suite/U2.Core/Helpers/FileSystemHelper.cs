using System;
using System.Collections.Generic;
using System.IO;
using U2.Core.Exceptions;

namespace U2.Core
{
    public static class FileSystemHelper
    {
        public static string GetAppDataFolderPath(string applicationName)
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(basePath, "U2Suite", "ApplicationData", applicationName);
        }

        public static string GetDatabaseFolderPath(string applicationName)
        {
            return Path.Combine(GetAppDataFolderPath(applicationName), "Database");
        }

        public static string GetFullPath(string fileName)
        {
            return GetFullPath(new string[] { fileName });
        }

        public static string GetFullPath(params string[] chunks)
        {
            var currentDirectory = Path.GetDirectoryName(typeof(FileSystemHelper).Assembly.Location);
            var pathElements = new List<string>(chunks);
            pathElements.Insert(0, currentDirectory);
            var fullPath = Path.Combine(pathElements.ToArray());
            return fullPath;
        }

        public static byte[] ReadFile(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    throw new FileIOException($"File {fileName} not found");
                }

                return File.ReadAllBytes(fileName);
            }
            catch (IOException ex)
            {
                throw new FileIOException($"Cannot read the file. Message: {ex.Message}");
            }
        }

        public static void WriteFile(string fileName, byte[] content)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                File.WriteAllBytes(fileName, content);
            }
            catch (IOException ex)
            {
                throw new FileIOException($"Cannot write the file. Message: {ex.Message}");
            }
        }
    }
}
