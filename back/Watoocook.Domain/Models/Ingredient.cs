using ValueOf;

namespace Watoocook.Domain.Models
{
    public class Ingredient : ValueOf<string, Ingredient>
    {
        public Ingredient ()
        {
        }

        public Ingredient(string val)
        {
            this.Value = val;
        }
    }
}
