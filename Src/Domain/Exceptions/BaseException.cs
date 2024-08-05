using Domain.Enums;
namespace Domain.Exceptions
{
    public class BaseException : Exception
    {
        public BaseExceptionValue Value { get; }

        public BaseException(string module, string error, ExceptionCode code, string message) : base(message) =>
            Value = new BaseExceptionValue(module, error, code, message);


        public record BaseExceptionValue(string Module, string Error, ExceptionCode Code, string Message);
    }
}


