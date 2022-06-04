namespace Watoocook.Domain.Models
{
    public class Recipe : BaseModel
    {
        public Recipe(string name, IEnumerable<Ingredient> ingredients, IEnumerable<string> tags)
        {
            Name = name;
            Ingredients = ingredients;
            Tags = tags;
        }

        public string Name { get; set; } = null!;
        public IEnumerable<Ingredient> Ingredients { get; set; } = null!;

        public IEnumerable<string> Tags { get; set; }
    }
}
