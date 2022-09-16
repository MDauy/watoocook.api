using Watoocook.Domain.Models;

namespace Watoocook.Api.Dtos
{
    public class AddRecipeDto
    {
        public string Name { get; set; } = "";

        public Dictionary<string, string> Ingredients { get; set; } = new Dictionary<string, string>();

        public IEnumerable<string>Tags { get; set; } = Enumerable.Empty<string>();
    }
}
