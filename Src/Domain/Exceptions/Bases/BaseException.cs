using Domain.Enums;
namespace Domain.Exceptions.Bases
{
    public abstract class BaseException(string module, string error, ExceptionCode code, string message) : Exception(message)
    {
        public BaseExceptionValue Value { get; } = new BaseExceptionValue(module, error, code, message);
        public sealed record BaseExceptionValue(string Module, string Error, ExceptionCode Code, string Message);
    }
}


