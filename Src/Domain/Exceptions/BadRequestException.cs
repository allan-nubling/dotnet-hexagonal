namespace Domain.Exceptions
{
    public class BadRequestException : HttpException
    {
        public BadRequestException(string message) : base(400, new BadRequestExceptionValue(message)) { }
    }

    public sealed record BadRequestExceptionValue(string Message) : BaseExceptionValue(nameof(BadRequestException));
}