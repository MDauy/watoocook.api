using System.Collections.Generic;

namespace Watoocook.Domain.Models
{
    public class Recipe : BaseModel
    {
        public Recipe(string name, Dictionary<Ingredient, Quantity> ingredients, IEnumerable<Tag> tags)
        {
            Name = name;
            Ingredients = ingredients;
            Tags = tags;
        }

        public string Name { get; set; } = null!;

        public Dictionary<Ingredient, Quantity> Ingredients{ get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}
