using Domain.Enums;
namespace Domain.Exceptions.Bases
{
    public abstract class AdapterException(string module, string error, ExceptionCode code, string message) : BaseException(module, error, code, message)
    {
    }
}


