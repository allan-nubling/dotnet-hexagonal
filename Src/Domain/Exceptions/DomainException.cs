
namespace Domain.Exceptions
{
    public class DomainException : Exception
    {
        public string Module { get; }
        public string Error { get; }
        public DomainException(string module, string error, string Message) : base(Message) =>
            (Module, Error) = (module, error);
    }
}


