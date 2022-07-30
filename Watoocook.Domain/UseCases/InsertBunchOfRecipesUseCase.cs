using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watoocook.Domain.Models;
using Watoocook.Domain.Repositories;

namespace Watoocook.Domain.UseCases
{
    public class InsertBunchOfRecipesUseCase
    {
        private IRecipeRepository _recipeRepository;

        public InsertBunchOfRecipesUseCase(IRecipeRepository recipeRepositorhy)
        {
            _recipeRepository = recipeRepositorhy;
        }

        public async Task InsertManyRecipes(List<Recipe> recipes)
        {
            if (!isValid(recipes))
                throw new Exception("One of the recipes is not valid");
            await _recipeRepository.InsertManyRecipes(recipes);
        }

        public static bool isValid(List<Recipe> recipes)
        {
            foreach (var recipe in recipes)
            {
                if (!recipe.IsValid())
                    return false;
            }
            return true;
        }
    }
}
