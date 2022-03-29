﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using U2.Core;
using U2.Resources;

namespace U2.Logger
{
    public static class LogInfoHelper
    {
        /// <summary>
        /// Loads a log info file from the database directory.
        /// </summary>
        /// <param name="logName">A name of the log to be loaded.</param>
        /// <returns>Returns a <see cref="LogInfo"/>.</returns>
        /// <exception cref="BadLogInfoException">Is thrown when log cannot be deserialized from file.</exception>
        /// <exception cref="LogInfoNotFoundException">Is thrown when log was not found.</exception>
        public static LogInfo LoadLogInfo(string logName)
        {
            var databaseDirectory = FileSystemHelper.GetDatabaseFolderPath(ApplicationNames.LoggerOsx);
            var logFileName = $"{logName}.json";
            var logInfoPath = Path.Combine(databaseDirectory, logFileName);
            try
            {
                using var stream = new FileStream(logInfoPath, FileMode.Open, FileAccess.Read, FileShare.Delete);
                return JsonSerializer.Deserialize<LogInfo>(stream);
            }
            catch (FileNotFoundException)
            {
                throw new LogInfoNotFoundException(logName);
            }
            catch (JsonException)
            {
                throw new BadLogInfoException(logName);
            }
        }

    }
}