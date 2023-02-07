using HA.Library.Core.Errors;
using HA.Library.Core.Primitives;
using HA.Library.Core.Primitives.Result;
using HA.Library.Core.Primitives.Result.Generics;

namespace HA.Library.Core.Features.Authors
{
    /// <summary>
    /// Represents the author name value object.
    /// </summary>
    public class AuthorName : ValueObject
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
        /// Initializes a new instance of the <see cref="AuthorName"/> class.
        /// </summary>
        /// <param name="value">The author name value.</param>
        private AuthorName(string value) => Value = value;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorName"/> class.
        /// </summary>
        /// <remarks>
        /// Required by some frameworks.
        /// </remarks>
        private AuthorName()
        {
        }

        public static implicit operator string(AuthorName name) => name?.Value ?? string.Empty;

        /// <summary>
        /// Creates a new <see cref="AuthorName"/> instance based on the specified value.
        /// </summary>
        /// <param name="name">The author name value.</param>
        /// <returns>The result of the author name creation process containing the author name or an error.</returns>
        public static Result<AuthorName> Create(string name) =>
            Result<string>.Create(name, DomainErrors.AuthorName.NullOrEmpty)
                .Ensure(x => !string.IsNullOrWhiteSpace(x), DomainErrors.BookName.NullOrEmpty)
                .Ensure(x => x.Length <= MaxLength, DomainErrors.BookName.LongerThanAllowed)
                .Map(x => new AuthorName(x));

        /// <inheritdoc />
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
