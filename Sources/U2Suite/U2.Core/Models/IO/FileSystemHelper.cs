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

        /// <summary>
        /// Calculates the path to the database folder.
        /// Without a trailing slash.
        /// </summary>
        /// <param name="applicationName">A name of the application to get the folder for.</param>
        /// <returns>Returns the path to the database folder for the given application.</returns>
        public static string GetDatabaseFolderPath(string applicationName)
        {
            if (GetDatabaseFolderFunc != null)
            {
                return GetDatabaseFolderFunc(applicationName);
            }
            return Path.Combine(GetAppDataFolderPath(applicationName), "Database");
        }

        public static Func<string, string> GetDatabaseFolderFunc { get; set; } = null;

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
