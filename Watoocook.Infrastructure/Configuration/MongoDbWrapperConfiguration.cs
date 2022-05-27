using Microsoft.Extensions.Configuration;

namespace MongoDBWrapper.Configuration
{
    public class MongoDbWrapperConfiguration
    {
        private readonly IConfiguration _configuration;

        public MongoDbWrapperConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString(string connectionName)
        {
            return _configuration.GetConnectionString(connectionName);
        }
    }
}
