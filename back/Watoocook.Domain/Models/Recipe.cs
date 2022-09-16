using System.Collections.Generic;

namespace Watoocook.Domain.Models
{
    public class Recipe : BaseModel
    {
        public Recipe(string name, Dictionary<string, string> ingredients, IEnumerable<string> tags, string? id = null)
        {
            Id = id!;
            Name = name;
            this.Ingredients = new Dictionary<Ingredient, Quantity>();
            foreach (var item in ingredients)
            {
                this.Ingredients.Add(new Ingredient(item.Key), new Quantity(item.Value));
            }
            Tags = tags.Select(tag => Tag.From(tag));
        }

        public Recipe(string name, Dictionary<Ingredient, Quantity> ingredients, IEnumerable<Tag> tags)
        {
            Name = name;
            Ingredients = ingredients;
            Tags = tags;
        }

        public string Name { get; set; } = null!;

        public Dictionary<Ingredient, Quantity> Ingredients { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public bool IsValid()
        {
            var error = string.Empty;
            if (string.IsNullOrEmpty(this.Name))
                error += "Missing name;";
            if (!this.Tags.Any())
                error += "Missing tags;";
            if (!this.Ingredients.Any())
                error += "Missing ingredients;";
            if (!string.IsNullOrEmpty(error))
                throw new ArgumentException(error);
            return true;
        }
    }
}
