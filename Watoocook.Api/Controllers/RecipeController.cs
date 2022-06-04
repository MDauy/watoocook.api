using Microsoft.AspNetCore.Mvc;
using Watoocook.Api.Dtos;
using Watoocook.Domain.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Watoocook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private GetRecipesByTagsUseCase _getRecipesByTags;
        public RecipeController (GetRecipesByTagsUseCase getRecipesByTags)
        {
            _getRecipesByTags = getRecipesByTags;
        }
        // GET: api/<RecipeController>
        [HttpGet]
        public async Task<IEnumerable<RecipeDto>> GetByTags([FromBody] IEnumerable<string> tags)
        {
            var recipesDto = new List<RecipeDto>();
            var domainRecipes =  await _getRecipesByTags.GetRecipesByTagsAsync(tags);
            foreach (var domainRecipe in domainRecipes)
            {
                recipesDto.Add(new RecipeDto(domainRecipe.Name, domainRecipe.Ingredients
            }
        }

        // POST api/<RecipeController>
        [HttpPost]
        public void Post([FromBody] RecipeDto recipe)
        {
        }

        // PUT api/<RecipeController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] RecipeDto recipe)
        {
        }

        // DELETE api/<RecipeController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}
