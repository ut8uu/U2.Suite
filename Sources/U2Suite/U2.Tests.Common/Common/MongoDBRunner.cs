using Mongo2Go;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Tests.Common.IO;

namespace U2.Tests.Common.Common;

public static class MongoDBRunner
{
    private static MongoDbRunner _dbRunner;

    private static IMongoClient _dbClient;

    public static string ConnectionString => _dbRunner.ConnectionString;

    public static void Start()
    {
        _dbRunner = MongoDbRunner.Start(Path.Combine(TemporaryDirectory.DefaultDirectory, "DB") + Path.DirectorySeparatorChar, null, null, singleNodeReplSet: true, null, 10);
        _dbClient = new MongoClient(_dbRunner.ConnectionString);
    }

    public static void Stop()
    {
        _dbClient = null;
        _dbRunner?.Dispose();
        _dbRunner = null;
    }

    public static IMongoDatabase CreateDatabase(string name)
    {
        _dbClient.DropDatabase(name);
        return _dbClient.GetDatabase(name);
    }
}
