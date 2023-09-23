namespace QueryBuilder
{
    public class FileRoot
    {
        public static string? Root { get; } = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
    }
}
