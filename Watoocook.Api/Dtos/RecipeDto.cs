using Watoocook.Api.Exceptions;
using Watoocook.Domain.Models;

namespace Watoocook.Api.Dtos
{
    public class RecipeDto
    {
        public string Id { get; set; } = null!;
        public RecipeDto(Recipe recipe)
        {
            Id = recipe.Id;
            Name = recipe.Name;
            this.Ingredients = new Dictionary<string, string>();
            foreach (var ingredient in recipe.Ingredients)
            {
                Ingredients.Add(ingredient.Key.ToString(), ingredient.Value.ToString());
            }
            Tags = recipe.Tags.Select(tag => tag.ToString());
        }

        public string Name { get; set; }

        public Dictionary<string, string> Ingredients { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
