using Watoocook.Domain.Models;
using Watoocook.Domain.Repositories;

namespace Watoocook.Domain.UseCases
{
    public class InsertRecipeUseCase
    {
        private IRecipeRepository _recipeRepository;
        public InsertRecipeUseCase(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task InsertRecipe(Recipe recipe)
        {
            if (recipe.IsValid())
                await _recipeRepository.InsertRecipe(recipe);
            else
                throw new Exception("Recipe not valid");
        }
    }
}
