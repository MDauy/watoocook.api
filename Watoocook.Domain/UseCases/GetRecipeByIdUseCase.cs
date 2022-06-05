using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watoocook.Domain.Models;
using Watoocook.Domain.Repositories;

namespace Watoocook.Domain.UseCases
{
    public class GetRecipeByIdUseCase
    {
        IRecipeRepository _recipeRepository;

        public GetRecipeByIdUseCase(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<Recipe> GetRecipeById(string recipeId)
        {
            try
            {
                var recipe = await _recipeRepository.GetById(recipeId);
                return new Recipe(recipe.Name, recipe.Ingredients, recipe.Tags);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
