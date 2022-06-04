using ValueOf;

namespace Watoocook.Domain.Models
{
    public class Ingredient : ValueOf<string, Ingredient>
    {
        public Ingredient()
        {
        }

        public Ingredient(string name)
        {
            Name = name;
        }

        public string Name { get; } = null!;
    }
}
