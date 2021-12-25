using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
    }
}
