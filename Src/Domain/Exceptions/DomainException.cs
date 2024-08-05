using Domain.Enums;

namespace Domain.Exceptions
{
    public class DomainException : BaseException
    {
        public DomainException(string module, string error, ExceptionCode code, string message) : base(module, error, code, message) { }
    }
}


