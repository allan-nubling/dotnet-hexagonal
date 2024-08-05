using System.Reflection;
using System.Resources;
using Domain.Enums;

namespace Domain.Exceptions
{
    public class AdapterException : BaseException
    {
        public AdapterException(string module, ExceptionCode code, string message) : base(module, nameof(AdapterException), code, message) { }
        public AdapterException(string module, ExceptionCode code) : base(module, nameof(AdapterException), code, MakeMessage(code)) { }
        static string MakeMessage(ExceptionCode code)
        {
            var resourceManager = new ResourceManager("Domain.Resources.Localization.ExceptionsMessages", Assembly.GetExecutingAssembly());
            return $"{resourceManager.GetString("AdapterException")} - {code}" ?? code.ToString();
        }
    }
}


