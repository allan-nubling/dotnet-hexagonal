
namespace Domain.Exceptions
{
    public class HttpException : Exception
    {
        public HttpException(int statusCode, BaseExceptionValue value) =>
            (StatusCode, Value) = (statusCode, value);

        public int StatusCode { get; }

        public BaseExceptionValue Value { get; }
    }

    public abstract record  BaseExceptionValue (string Error);
}

