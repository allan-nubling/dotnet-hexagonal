using System.Reflection;
using System.Resources;
using Domain.Enums;
namespace Domain.Exceptions
{
    public class ForbiddenException : BaseException
    {
        public ForbiddenException(string module, ExceptionCode code, string message) : base(module, nameof(ForbiddenException), code, message) { }
        public ForbiddenException(string module, ExceptionCode code) : base(module, nameof(ForbiddenException), code, MakeMessage(code)) { }
        static string MakeMessage(ExceptionCode code)
        {
            var resourceManager = new ResourceManager("Domain.Resources.Localization.ExceptionsMessages", Assembly.GetExecutingAssembly());
            return $"{resourceManager.GetString("ForbiddenException")} - {code}" ?? code.ToString();
        }
    }
}