using MongoDBWrapper.Repositories;
using Watoocook.Domain.Models;
using Watoocook.Domain.Repositories;
using Watoocook.Infrastructure.Documents;

namespace Watoocook.Infrastructure.Repositories
{
    public class RecipeRepository : BaseRepository<RecipeDocument>, IRecipeRepository
    {

        public async Task<IEnumerable<Recipe>> GetRecipesByTagsAsync(IEnumerable<string> tags)
        {
            var result = new List<Recipe>();
            var recipes = await Get(recipe => recipe.Tags.Select(x => x.ToString()).Intersect(tags).Any());
            foreach (var recipe in recipes)
            {
                result.Add(new Recipe(recipe.Name, recipe.Ingredients, recipe.Tags, recipe.Oid.ToString()));
            }
            return result;
        }

        public async Task InsertRecipe(Recipe recipe)
        {
            await Insert(new RecipeDocument(recipe));
        }

        public async Task DeleteRecipe(string recipeId)
        {
            if (!await Delete(recipeId))
                throw new Exception($"Recipe {recipeId} deletion went wrong");
        }

        public async Task<Recipe> GetById(string recipeId)
        {
            var recipe = await Get(recipeId);
            if (recipe != null)
            {
                return new Recipe(recipe.Name, recipe.Ingredients, recipe.Tags, recipe.Oid.ToString());
            }
            throw new Exception("Recipe not found");
        }

        public async Task InsertManyRecipes(List<Recipe> recipes)
        {
            var recipeDocuments = new List<RecipeDocument>();
            recipes.ForEach(recipe =>
            {
                recipeDocuments.Add(new RecipeDocument(recipe));
            });
            await Collection.InsertManyAsync(recipeDocuments);
        }
    }
}
