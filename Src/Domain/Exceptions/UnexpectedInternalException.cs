using System.Reflection;
using System.Resources;
using Domain.Enums;
using Domain.Exceptions.Bases;

namespace Domain.Exceptions
{
    public sealed class UnexpectedInternalException : InternalException
    {
        public UnexpectedInternalException(string module, ExceptionCode code, string message) : base(module, nameof(UnexpectedInternalException), code, message) { }
        public UnexpectedInternalException(string module, ExceptionCode code) : base(module, nameof(UnexpectedInternalException), code, MakeMessage(code)) { }
        static string MakeMessage(ExceptionCode code)
        {
            var resourceManager = new ResourceManager("Domain.Resources.Localization.ExceptionsMessages", Assembly.GetExecutingAssembly());
            return $"{resourceManager.GetString("UnexpectedInternalException")} - {code}" ?? code.ToString();
        }
    }
}


