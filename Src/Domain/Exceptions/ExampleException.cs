
using System.Reflection;
using System.Resources;
using Domain.Enums;

namespace Domain.Exceptions
{
    public class ExampleException : DomainException
    {
        public ExampleException(string module, ExceptionCode code) : base(module, nameof(ExampleException), code, MakeMessage(code))
        {
        }
        static string MakeMessage(ExceptionCode code)
        {
            var resourceManager = new ResourceManager("Domain.Resources.Localization.ExceptionsMessages", Assembly.GetExecutingAssembly());
            return $"{resourceManager.GetString("ExampleException")} {code}" ?? code.ToString();
        }
    }
}


