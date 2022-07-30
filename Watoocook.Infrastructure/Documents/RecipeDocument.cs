using MongoDBWrapper.Documents;
using Watoocook.Domain.Models;

namespace Watoocook.Infrastructure.Documents
{
    public class RecipeDocument : BaseDocument
    {
        public RecipeDocument(string name)
        {
            Name = name;
            Ingredients = new Dictionary<string, string>();
            Tags = new List<string>();
        }

        public RecipeDocument (Recipe recipe)
        {
            Name=recipe.Name;
            this.Ingredients = new Dictionary<string, string>();
            foreach (var item in recipe.Ingredients)
            {
                this.Ingredients.Add(item.Key.ToString(), item.Value.ToString());
            }
            Tags = recipe.Tags.Select(tag => tag.ToString());
        }

        public string Name { get; set; }
        public Dictionary<string, string> Ingredients { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
