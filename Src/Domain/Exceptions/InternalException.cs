using System.Reflection;
using System.Resources;
using Domain.Enums;

namespace Domain.Exceptions
{
    public class InternalException : BaseException
    {
        public InternalException(string module, ExceptionCode code, string message) : base(module, nameof(AdapterException), code, message) { }
        public InternalException(string module, ExceptionCode code) : base(module, nameof(InternalException), code, MakeMessage(code)) { }
        static string MakeMessage(ExceptionCode code)
        {
            var resourceManager = new ResourceManager("Domain.Resources.Localization.ExceptionsMessages", Assembly.GetExecutingAssembly());
            return $"{resourceManager.GetString("InternalException")} - {code}" ?? code.ToString();
        }
    }
}


