namespace U2.Tests.Common
{
    public sealed class TempDirectory : IDisposable
    {
        private readonly string _tempDirectory;

        public TempDirectory(string tempDirectory)
        {
            _tempDirectory = tempDirectory;

            Directory.CreateDirectory(_tempDirectory);
        }

        public void Dispose()
        {
            Directory.Delete(_tempDirectory, true);
        }
    }
}