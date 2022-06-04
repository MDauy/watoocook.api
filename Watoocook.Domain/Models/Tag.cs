using ValueOf;

namespace Watoocook.Domain.Models
{
    public class Tag : ValueOf<string, Tag>
    {
        public Tag()
        {
            Name = string.Empty;
        }

        public Tag(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }
}
