using Microsoft.AspNetCore.Mvc;
using Watoocook.Api.Dtos;
using Watoocook.Api.Exceptions;
using Watoocook.Domain.Models;
using Watoocook.Domain.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Watoocook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private GetRecipesByTagsUseCase _getRecipesByTagsUseCase;
        private InsertRecipeUseCase _insertRecipeUseCase;
        private DeleteRecipeUseCase _deleteRecipeUseCase;
        public RecipeController (GetRecipesByTagsUseCase getRecipesByTags,
            InsertRecipeUseCase insertRecipeUserCase,
            DeleteRecipeUseCase deleteRecipeUseCase)
        {
            _getRecipesByTagsUseCase = getRecipesByTags;
            _insertRecipeUseCase = insertRecipeUserCase;
            _deleteRecipeUseCase = deleteRecipeUseCase;
        }
        // GET: api/<RecipeController>
        [HttpGet]
        public async Task<IEnumerable<RecipeDto>> GetByTags([FromBody] IEnumerable<string> tags)
        {
            var recipesDto = new List<RecipeDto>();
            var domainRecipes =  await _getRecipesByTagsUseCase.GetRecipesByTagsAsync(tags);
            foreach (var domainRecipe in domainRecipes)
            {
                recipesDto.Add(new RecipeDto(domainRecipe.Name, domainRecipe.Ingredients, domainRecipe.Tags));
            }
            return recipesDto;
        }

        // PUT api/<RecipeController>/5
        [HttpPut("{id}")]
        public async Task <IActionResult> Put([FromBody] RecipeDto recipe)
        {
            try
            {
                recipe.Validate();
                var domainRecipe = new Recipe(recipe.Name, recipe.Ingredients, recipe.Tags);
                await _insertRecipeUseCase.InsertRecipe(domainRecipe);
                return Ok(recipe);
            }
            catch (InvalidObjectException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<RecipeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _deleteRecipeUseCase.DeleteRecipe(id);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}
