using Watoocook.Api.Exceptions;
using Watoocook.Domain.Models;

namespace Watoocook.Api.Dtos
{
    public class RecipeDto : BaseDto
    {
        public RecipeDto(string name, Dictionary<Ingredient, Quantity> ingredients, IEnumerable<Tag> tags)
        {
            Name = name;
            Ingredients = ingredients;
            Tags = tags;
        }

        public string Name { get; }

        public Dictionary<Ingredient, Quantity> Ingredients { get; }

        public IEnumerable<Tag> Tags { get; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new InvalidObjectException("Invalid recipe name");
            }
        }
    }
}
