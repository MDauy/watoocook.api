using Watoocook.Domain.Models;
using Watoocook.Domain.Repositories;

namespace Watoocook.Domain.UseCases
{
    public class GetRecipesByTagsUseCase
    {
        private IRecipeRepository _recipeRepository;
        public GetRecipesByTagsUseCase(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public async Task<IEnumerable<Recipe>> GetRecipesByTagsAsync (IEnumerable<string> tags)
        {
            if (tags.Any())
                return await _recipeRepository.GetRecipesByTagsAsync(tags);
            else
                throw new ArgumentNullException(nameof(tags));
        }
    }
}
