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
            if (string.IsNullOrEmpty(recipeId))
                throw new ArgumentNullException(nameof(recipeId));
            try
            {
                var recipe = await _recipeRepository.GetById(recipeId);
                return recipe!;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
