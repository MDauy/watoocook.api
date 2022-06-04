using Microsoft.Extensions.DependencyInjection;
using MongoDBWrapper.Repositories;
using Watoocook.Domain.Repositories;
using Watoocook.Infrastructure.Documents;
using Watoocook.Infrastructure.Repositories;

namespace Watoocook.Infrastructure
{
    public static class IServiceCollectionExtension_Infrastructure
    {
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IBaseRepository<RecipeDocument>, BaseRepository<RecipeDocument>>();
            serviceCollection.AddSingleton<IRecipeRepository, RecipeRepository>(); 
        }
    }
}
