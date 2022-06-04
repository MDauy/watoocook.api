﻿using Watoocook.Domain.Models;
using Watoocook.Domain.Repositories;

namespace Watoocook.Domain.UseCases
{
    public class DeleteRecipeUseCase
    {
        IRecipeRepository _recipeRepository;

        public DeleteRecipeUseCase(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task DeleteRecipe(string recipeId)
        {
            try
            {
                await _recipeRepository.DeleteRecipe(recipeId);
            }
            catch (Exception)
            {
                throw;
            }
            }
        }
    }