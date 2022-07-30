using Watoocook.Domain.Models;

namespace Watoocook.Domain.Repositories
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetRecipesByTagsAsync(IEnumerable<string> tags);

        Task<Recipe> GetById(string recipeId);
        Task InsertRecipe(Recipe recipe);
        Task DeleteRecipe(string recipeId);
        Task InsertManyRecipes(List<Recipe> recipes);
    }
}
