using HA.Library.Core.Errors;
using HA.Library.Core.Primitives;
using HA.Library.Core.Primitives.Result;
using HA.Library.Core.Primitives.Result.Generics;

namespace HA.Library.Core.Features.Books
{
    /// <summary>
    /// Represents the book name value object.
    /// </summary>
    public sealed class BookName : ValueObject
    {
        /// <summary>
        /// The name maximum length.
        /// </summary>
        public const int MaxLength = 100;

        /// <summary>
        /// Gets the name value.
        /// </summary>
        public string Value { get; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookName"/> class.
        /// </summary>
        /// <param name="value">The book name value.</param>
        private BookName(string value) => Value = value;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookName"/> class.
        /// </summary>
        /// <remarks>
        /// Required by some frameworks.
        /// </remarks>
        private BookName()
        {
        }

        public static implicit operator string(BookName name) => name?.Value ?? string.Empty;

        /// <summary>
        /// Creates a new <see cref="BookName"/> instance based on the specified value.
        /// </summary>
        /// <param name="name">The book name value.</param>
        /// <returns>The result of the book name creation process containing the book name or an error.</returns>
        public static Result<BookName> Create(string name) =>
            Result<string>.Create(name, DomainErrors.BookName.NullOrEmpty)
                .Ensure(x => !string.IsNullOrWhiteSpace(x), DomainErrors.BookName.NullOrEmpty)
                .Ensure(x => x.Length <= MaxLength, DomainErrors.BookName.LongerThanAllowed)
                .Map(x => new BookName(x));

        /// <inheritdoc />
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
