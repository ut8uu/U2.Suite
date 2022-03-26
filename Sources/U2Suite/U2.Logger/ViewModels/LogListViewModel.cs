using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using U2.Core;

namespace U2.Logger
{
    public sealed class LogListViewModel
    {
        public LogListViewModel(string directory)
        {
            List = LoadLogs(directory);
        }

        public LogList List { get; }

        internal static LogList LoadLogs(string logDirectory)
        {
            var result = new LogList();

            var sqliteFiles = Directory.EnumerateFiles(logDirectory, $"*.json");
            foreach (var file in sqliteFiles)
            {
                using var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Delete);
                var logInfoFile = JsonSerializer.Deserialize<LogInfo>(stream);
                if (logInfoFile == null)
                {
                    continue;
                }
                result.Logs.Add(logInfoFile);
            }

            return result;
        }

    }
}
