namespace Watoocook.Api.Dtos
{
    public abstract class BaseDto
    {
        public string Id { get; set; } = null!;

        public abstract void Validate ();
    }
}
