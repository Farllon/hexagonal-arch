using HA.Library.Core.Utility;
using HA.Library.Core.Primitives;
using HA.Library.Core.Primitives.Result;

namespace HA.Library.Core.Features.Authors
{
    /// <summary>
    /// Represents the author entity.
    /// </summary>
    public class Author : Entity
    {
        /// <summary>
        /// Gets the auhor name.
        /// </summary>
        public AuthorName AuthorName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="authorName">The author name.</param>
        public Author(AuthorName authorName)
        {
            Ensure.NotNull(authorName, "The author name is required.", nameof(authorName));

            AuthorName = authorName;
        }

        /// <summary>
        /// Updates the author information.
        /// </summary>
        /// <param name="authorName">The author name.</param>
        /// <returns>The success result if the update operation was successful, otherwise a failure result with an error.</returns>
        public Result UpdateInformation(AuthorName authorName)
        {
            Ensure.NotNull(authorName, "The author name is required.", nameof(authorName));

            AuthorName = authorName;

            return Result.Success();
        }
    }
}
