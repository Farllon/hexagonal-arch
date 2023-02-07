using HA.Library.Core.Primitives;

namespace HA.Library.Core.Errors
{
    /// <summary>
    /// Contains the domain errors.
    /// </summary>
    public static partial class DomainErrors
    {
        /// <summary>
        /// Contains the author name errors.
        /// </summary>
        public static class AuthorName
        {
            /// <summary>
            /// Gets the author name is null or empty error.
            /// </summary>
            public static Error NullOrEmpty => new Error("AuthorName.NullOrEmpty", "The author name is required.");

            /// <summary>
            /// Gets the author name is longer than allowed error.
            /// </summary>
            public static Error LongerThanAllowed => new Error("AuthorName.LongerThanAllowed", "The author name is longer than allowed.");
        }
    }
}
