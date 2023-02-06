using HA.Library.Core.Primitives;

namespace HA.Library.Core.Books
{
    public class BookName
    {
        public string Value { get; private set; }

        public BookName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                throw ValidationException.FromError(BookErrors.InvalidName);

            Value = value;
        }
    }
}
