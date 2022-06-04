using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watoocook.Domain.UseCases;

namespace Watoocook.Domain
{
    public static class IServiceCollectionExtension_Domain
    {
        public static void AddUseCases(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<GetRecipesByTagsUseCase>();
        }
    }
}
