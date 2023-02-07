using HA.Library.Core.Errors;
using HA.Library.Core.Utility;
using HA.Library.Core.Primitives;
using HA.Library.Core.Features.Authors;
using HA.Library.Core.Primitives.Result;

namespace HA.Library.Core.Features.Books
{
    /// <summary>
    /// Represents the book entity.
    /// </summary>
    public class Book : Entity
    {
        /// <summary>
        /// Gets the book name.
        /// </summary>
        public BookName BookName { get; private set; }

        public readonly List<Author> _authors = new List<Author>();

        /// <summary>
        /// Gets the book authors.
        /// </summary>
        public IReadOnlyCollection<Author> Authors => _authors.AsReadOnly();

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="bookName">The author name.</param>
        /// <param name="modelName">The model name.</param>
        public Book(BookName bookName)
        {
            Ensure.NotNull(bookName, "The book name is required.", nameof(bookName));

            BookName = bookName;
        }

        /// <summary>
        /// Updates the book information.
        /// </summary>
        /// <param name="bookName">The book name.</param>
        /// <returns>The success result if the update operation was successful, otherwise a failure result with an error.</returns>
        public Result UpdateInformation(BookName bookName)
        {
            Ensure.NotNull(bookName, "The book name is required.", nameof(bookName));

            BookName = bookName;

            return Result.Success();
        }

        /// <summary>
        /// Adds an author to the book.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <returns>The success result if the operation was successful, otherwise a failure result with an error.</returns>
        public Result AddAuthor(Author author)
        {
            Result result = CheckIfAuthorCanBeAdded(author);

            if (result.IsFailure)
            {
                return result;
            }

            _authors.Add(author);

            return Result.Success();
        }

        /// <summary>
        /// Checks if the author can be added.
        /// </summary>
        /// <returns>The success result if the author can be added, otherwise a failure result and an error.</returns>
        private Result CheckIfAuthorCanBeAdded(Author newAuthor)
        {
            if (_authors.Exists(author => author.AuthorName.Equals(newAuthor.AuthorName)))
            {
                return Result.Failure(DomainErrors.Book.AuthorExists);
            }

            return Result.Success();
        }
    }
}
