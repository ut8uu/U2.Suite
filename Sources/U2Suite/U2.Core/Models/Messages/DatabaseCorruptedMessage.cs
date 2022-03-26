namespace U2.Core.Models
{
    public sealed class DatabaseCorruptedMessage
    {
        public DatabaseCorruptedMessage(string name)
        {
            CorruptedDatabaseName = name;
        }

        public string CorruptedDatabaseName { get; init; }
    }
}
