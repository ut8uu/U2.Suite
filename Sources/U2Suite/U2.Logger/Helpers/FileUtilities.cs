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
