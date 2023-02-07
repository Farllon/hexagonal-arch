namespace HA.Library.Core.Primitives.Result.Generics
{
    /// <summary>
    /// Represents the result of some operation, with status information and possibly a value and an error.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    public class Result<TValue> : Result
    {
        private readonly TValue _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TValueType}"/> class with the specified parameters.
        /// </summary>
        /// <param name="value">The result value.</param>
        /// <param name="isSuccess">The flag indicating if the result is successful.</param>
        /// <param name="error">The error.</param>
        protected internal Result(TValue value, bool isSuccess, Error error)
            : base(isSuccess, error)
            => _value = value;

        /// <summary>
        /// Gets the result value if the result is successful, otherwise throws an exception.
        /// </summary>
        /// <returns>The result value if the result is successful.</returns>
        /// <exception cref="InvalidOperationException"> when <see cref="Result.IsFailure"/> is true.</exception>
        public TValue Value => IsSuccess
            ? _value
            : throw new InvalidOperationException("The value of a failure result can not be accessed.");

        /// <summary>
        /// Returns a success <see cref="Result{TValue}"/> with the specified value.
        /// </summary>
        /// <typeparam name="TValue">The result type.</typeparam>
        /// <param name="value">The result value.</param>
        /// <returns>A new instance of <see cref="Result{TValue}"/> with the success flag set.</returns>
        public static Result<TValue> Success(TValue value) => new Result<TValue>(value, true, Error.None);

        /// <summary>
        /// Creates a new <see cref="Result{TValue}"/> with the specified nullable value and the specified error.
        /// </summary>
        /// <typeparam name="TValue">The result type.</typeparam>
        /// <param name="value">The result value.</param>
        /// <param name="error">The error in case the value is null.</param>
        /// <returns>A new instance of <see cref="Result{TValue}"/> with the specified value or an error.</returns>
        public static Result<TValue> Create(TValue value, Error error)
            => value is null ? Result<TValue>.Failure(error) : Success(value);

        /// <summary>
        /// Returns a failure <see cref="Result{TValue}"/> with the specified error.
        /// </summary>
        /// <typeparam name="TValue">The result type.</typeparam>
        /// <param name="error">The error.</param>
        /// <returns>A new instance of <see cref="Result{TValue}"/> with the specified error and failure flag set.</returns>
        /// <remarks>
        /// We're purposefully ignoring the nullable assignment here because the API will never allow it to be accessed.
        /// The value is accessed through a method that will throw an exception if the result is a failure result.
        /// </remarks>
        public static new Result<TValue> Failure(Error error) => new Result<TValue>(default!, false, error);

        /// <summary>
        /// Returns the first failure from the specified <paramref name="results"/>.
        /// If there is no failure, a success is returned.
        /// </summary>
        /// <param name="results">The results array.</param>
        /// <returns>
        /// The first failure from the specified <paramref name="results"/> array,or a success it does not exist.
        /// </returns>

        public static implicit operator Result<TValue>(TValue value) => Success(value);
    }
}