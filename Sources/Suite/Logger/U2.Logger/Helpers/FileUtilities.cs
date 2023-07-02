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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Core.Exceptions;

namespace U2.Logger
{
    public static class FileUtilities
    {
        public static async Task<bool> SaveAsync(string pathToFile, byte[] content, bool useBackup)
        {
            var backupFileName = $"{pathToFile}.bak";

            try
            {
                if (File.Exists(backupFileName))
                {
                    File.Delete(backupFileName);
                }

                if (useBackup && File.Exists(pathToFile))
                {
                    File.Move(pathToFile, backupFileName);
                }

                var directory = Path.GetDirectoryName(pathToFile);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                await File.WriteAllBytesAsync(pathToFile, content);
                return true;
            }
            catch (Exception ex)
            {
                throw new FileWriteException($"Error writing to '{pathToFile}'", ex);
            }
        }

        public static async Task<(bool, byte[])> LoadAsync(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                return (false, Array.Empty<byte>());
            }

            try
            {
                var content = await File.ReadAllBytesAsync(pathToFile);
                return (true, content);
            }
            catch (Exception ex)
            {
                throw new FileReadException(ex.Message, ex);
            }
        }
    }
}
