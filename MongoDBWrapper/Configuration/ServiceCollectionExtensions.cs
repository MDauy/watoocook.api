using Microsoft.Extensions.DependencyInjection;

namespace MongoDBWrapper.Configuration
{
    /// <summary>
    /// ServiceCollectionExtensions to declare DI that's proper to the wrapper.
    /// TODO : add it to the Startup class (API, Console, etc.).
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Injects the configuration service.
        /// </summary>
        /// <param name="services">ServiceCollection.</param>
        public static void AddMongodbWrapperConfiguration(this IServiceCollection services)
        {
            services.AddScoped<MongoDbWrapperConfiguration>();
        }
    }
}
