
using System.Reflection;
using System.Resources;
using Domain.Enums;
using Domain.Exceptions.Bases;
namespace Domain.Exceptions
{
    public sealed class ExampleException(string module, ExceptionCode code) : DomainException(module, nameof(ExampleException), code, MakeMessage(code))
    {
        static string MakeMessage(ExceptionCode code)
        {
            var resourceManager = new ResourceManager("Domain.Resources.Localization.ExceptionsMessages", Assembly.GetExecutingAssembly());
            return $"{resourceManager.GetString("ExampleException")} {code}" ?? code.ToString();
        }
    }
}


