using Microsoft.Extensions.DependencyInjection;
using Watoocook.Domain.UseCases;

namespace Watoocook.Domain
{
    public static class IServiceCollectionExtension_Domain
    {
        public static void AddUseCases(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<GetRecipesByTagsUseCase>();
            serviceCollection.AddSingleton<InsertRecipeUseCase>();
            serviceCollection.AddSingleton<DeleteRecipeUseCase>();
            serviceCollection.AddSingleton<GetRecipeByIdUseCase>();
        }
    }
}
