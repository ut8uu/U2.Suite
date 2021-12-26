using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using U2.Core.Exceptions;

namespace U2.Core
{
    public static class FileSystemHelper
    {
        public static string GetFullPath(string fileName)
        {
            var currentDirectory = Path.GetDirectoryName(typeof(FileSystemHelper).Assembly.Location);
            var fullPath = Path.Combine(currentDirectory, fileName);
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
