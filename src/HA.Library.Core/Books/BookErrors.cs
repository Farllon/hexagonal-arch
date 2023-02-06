using HA.Library.Core.Primitives;

namespace HA.Library.Core.Books
{
    public static class BookErrors
    {
        public static Error InvalidName = new Error(nameof(InvalidName), "The name of the book must contain at least 5 letters");
    }
}
