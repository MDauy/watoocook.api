using MongoDBWrapper.Documents;
using Watoocook.Domain.Models;

namespace Watoocook.Infrastructure.Documents
{
    public class RecipeDocument : BaseDocument
    {
        public RecipeDocument(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Tags = new List<string>();
        }

        public RecipeDocument(string name, IEnumerable<Ingredient> ingredients, IEnumerable<string> tags) : this(name)
        {
            Ingredients = ingredients;
            Tags = tags;
        }

        public string Name { get; set; } = null!;
        public IEnumerable<Ingredient> Ingredients { get; set; } = null!;

        public IEnumerable<string> Tags { get; set; } = null!;
    }
}
