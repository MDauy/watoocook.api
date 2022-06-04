using MongoDBWrapper.Documents;
using Watoocook.Domain.Models;

namespace Watoocook.Infrastructure.Documents
{
    public class RecipeDocument : BaseDocument
    {
        public RecipeDocument(string name)
        {
            Name = name;
            Ingredients = new Dictionary<Ingredient, Quantity>();
            Tags = new List<Tag>();
        }

        public RecipeDocument (Recipe recipe)
        {
            Name=recipe.Name;
            Ingredients = recipe.Ingredients;
            Tags = recipe.Tags;
        }

        public string Name { get; }
        public Dictionary<Ingredient, Quantity> Ingredients { get; set; }

        public IEnumerable<Tag> Tags { get; }
    }
}
