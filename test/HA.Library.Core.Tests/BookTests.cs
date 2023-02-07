using HA.Library.Core.Errors;
using HA.Library.Core.Features.Books;

namespace HA.Library.Core.Tests
{
    public class BookTests
    {
        [Fact]
        public void WhenTryCreateANullBookNameThenResultIsFailure()
        {
            var expected = DomainErrors.BookName.NullOrEmpty;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var actual = BookName.Create(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            Assert.True(actual.IsFailure);
            Assert.Equal(expected, actual.Error);
        }

        [Fact]
        public void WhenTryCreateAnEmptyBookNameThenResultIsFailure()
        {
            var expected = DomainErrors.BookName.NullOrEmpty;
            var actual = BookName.Create(string.Empty);

            Assert.True(actual.IsFailure);
            Assert.Equal(expected, actual.Error);
        }

        [Fact]
        public void WhenTryCrateBookNameWithMoreThan100CharsThenReultIsFailure()
        {
            var expected = DomainErrors.BookName.LongerThanAllowed;
            var actual = BookName.Create(new string('0', BookName.MaxLength + 1));

            Assert.True(actual.IsFailure);
            Assert.Equal(expected, actual.Error);
        }

        [Fact]
        public void WhenTryCreateAValidBookNameThenResultIsSuccess()
        {
            var expected = BookName.Create("Valid book name");
            var actual = BookName.Create(expected.Value);

            Assert.True(actual.IsSuccess);
            Assert.True(expected.Value.Equals(actual.Value));
        }
    }
}
