namespace Domain.Exceptions
{
    public class ServerException : HttpException
    {
        public ServerException(string message, string code) : base(500, new ServerExceptionValue(message, code)) { }


    }

    public sealed record ServerExceptionValue(string Module, string Message) : BaseExceptionValue(nameof(ServerException));
}