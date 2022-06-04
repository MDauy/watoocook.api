namespace Watoocook.Domain.Models
{
    public struct Ingredient
    {
        public Ingredient(string name, string quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public string Name { get; set; } = null!;
        public string Quantity { get; set; } = null!;
    }
}
