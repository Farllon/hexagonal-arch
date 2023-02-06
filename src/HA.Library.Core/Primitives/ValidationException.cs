namespace HA.Library.Core.Primitives
{
    public class ValidationException : Exception
    {
        public string Code { get; private set; }

        public ValidationException(string code, string message)
            : base(message)
        {
            Code = code;
        }

        public static ValidationException FromError(Error error)
            => new(error.Code, error.Message);
    }
}
