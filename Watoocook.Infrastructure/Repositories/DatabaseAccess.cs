using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDBWrapper.Configuration;

namespace MongoDBWrapper.Repositories
{
    public static class DataBaseAccess
	{
		private static MongoClient _client;
		private static IMongoDatabase _db;

		public static MongoClient Client
		{
			get
			{
				if (_client == null)
				{
					using (var serviceScope = ServiceActivator.GetScope())
					{
                        var config = serviceScope?.ServiceProvider.GetService<MongoDbWrapperConfiguration>();
						_client = new MongoClient(config!.GetConnectionString("mongodb"));
					}
				}
				return _client;
			}

		}

		public static IMongoDatabase Db
		{
			get
			{
				if (_db == null)
				{
					_db = Client.GetDatabase("suggebook");
				};

				return _db;
			}
		}
	}
}
