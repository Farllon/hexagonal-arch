using HA.Library.Core.Primitives;

namespace HA.Library.Core.Errors
{
    /// <summary>
    /// Contains the domain errors.
    /// </summary>
    public static partial class DomainErrors
    {
        /// <summary>
        /// Contains the book name errors.
        /// </summary>
        public static class BookName
        {
            /// <summary>
            /// Gets the book name is null or empty error.
            /// </summary>
            public static Error NullOrEmpty => new Error("BookName.NullOrEmpty", "The book name is required.");

            /// <summary>
            /// Gets the book name is longer than allowed error.
            /// </summary>
            public static Error LongerThanAllowed => new Error("BookName.LongerThanAllowed", "The book name is longer than allowed.");
        }
    }
}
