using HA.Library.Core.Primitives;

namespace HA.Library.Core.Errors
{
    /// <summary>
    /// Contains the domain errors.
    /// </summary>
    public static partial class DomainErrors
    {
        /// <summary>
        /// Contains the book errors.
        /// </summary>
        public static class Book
        {
            /// <summary>
            /// Gets the author is in book.
            /// </summary>
            public static Error AuthorExists => new Error("Book.AuthorExists", "The author alreadys in book.");
        }
    }
}
