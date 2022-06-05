using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDBWrapper.Configuration;

namespace MongoDBWrapper.Repositories
{
    public static class DataBaseAccess
    {
        private static MongoClient _client = null!;
        private static IMongoDatabase _db = null!;

        public static MongoClient Client
        {
            get
            {
                if (_client == null)
                {
                    using (var serviceScope = ServiceActivator.GetScope())
                    {
                        var config = serviceScope?.ServiceProvider.GetService<MongoDbWrapperConfiguration>();
                        if (config != null)
                        {
                            var connectionString = config.GetConnectionString("mongodb");
                            if (connectionString != null)
                                _client = new MongoClient();
                            else
                                throw new Exception("Connection string not found");
                        }
                        else
                            throw new Exception("MongoDbWrapperConfiguration is null");
                    }
                }
                return _client;
            }

        }

        public static IMongoDatabase Db
        {
            get
            {
                try
                {
                    if (_db == null)
                    {
                        using (var serviceScope = ServiceActivator.GetScope())
                        {
                            var config = serviceScope?.ServiceProvider.GetService<MongoDbWrapperConfiguration>();
                            _db = Client.GetDatabase(config!.GetDatabaseName());
                        }
                    };

                    return _db;
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
