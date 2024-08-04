
namespace Domain.Exceptions
{
    public class ExampleException(string module, string Message) : DomainException(module, nameof(ExampleException), Message)
    {
    }
}


