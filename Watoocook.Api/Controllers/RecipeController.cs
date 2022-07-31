using Microsoft.AspNetCore.Mvc;
using Watoocook.Api.Dtos;
using Watoocook.Domain.Models;
using Watoocook.Domain.UseCases;

namespace Watoocook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : Controller
    {
        private GetRecipesByTagsUseCase _getRecipesByTagsUseCase;
        private AddRecipeUseCase _insertRecipeUseCase;
        private DeleteRecipeUseCase _deleteRecipeUseCase;
        private GetRecipeByIdUseCase _getRecipeByIdUserCase;
        private AddManyRecipesUserCase _insertBunchOfRecipes;
        public RecipeController(GetRecipesByTagsUseCase getRecipesByTags,
            AddRecipeUseCase insertRecipeUserCase,
            DeleteRecipeUseCase deleteRecipeUseCase,
            GetRecipeByIdUseCase getRecipeByIdUseCase,
            AddManyRecipesUserCase insertBunchOfRecipes)
        {
            _getRecipesByTagsUseCase = getRecipesByTags;
            _insertRecipeUseCase = insertRecipeUserCase;
            _deleteRecipeUseCase = deleteRecipeUseCase;
            _getRecipeByIdUserCase = getRecipeByIdUseCase;
            _insertBunchOfRecipes = insertBunchOfRecipes;
        }
        // GET: api/<RecipeController>
        [HttpGet("getbytags")]
        public async Task<IActionResult> GetByTags([FromQuery] string[] tags)
        {
            try
            {
                var recipesDto = new List<RecipeDto>();
                var domainRecipes = await _getRecipesByTagsUseCase.GetRecipesByTagsAsync(tags);
                foreach (var domainRecipe in domainRecipes)
                {
                    recipesDto.Add(new RecipeDto(domainRecipe));
                }
                return StatusCode(200,recipesDto);
            }
            catch (ArgumentNullException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var recipe = await _getRecipeByIdUserCase.GetRecipeById(id);

                return StatusCode(200, new RecipeDto(recipe));
            }
            catch (ArgumentNullException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<RecipeController>/5
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRecipeDto recipe)
        {
            try
            {
                var domainRecipe = new Recipe(recipe.Name, recipe.Ingredients, recipe.Tags.Select(x => x.ToString()));
                await _insertRecipeUseCase.InsertRecipe(domainRecipe);
                return Ok(recipe);
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("insertmany")]
        public async Task<IActionResult> InsertManyRecipes(List<RecipeDto> recipes)
        {
            try
            {
                var recipeModels = new List<Recipe>();
                foreach (var recipe in recipes)
                {
                    recipeModels.Add(new Recipe(recipe.Name, recipe.Ingredients, recipe.Tags));
                }

                await _insertBunchOfRecipes.InsertManyRecipes(recipeModels);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
