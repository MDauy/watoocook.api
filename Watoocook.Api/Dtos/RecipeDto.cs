using Watoocook.Domain.Models;

namespace Watoocook.Api.Dtos
{
    public class RecipeDto : BaseDto
    {
        public RecipeDto(string name, IEnumerable<Ingredient> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }

        public string Name { get; set; } = null!;
        public IEnumerable<Ingredient> Ingredients { get; set; } = null!;
        public IEnumerable<string> Tags { get; set; }
    }
}
