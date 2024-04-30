namespace Domain.Exceptions
{
    public class SampleException : HttpException
    {
        public SampleException(string message, string code) : base(400, new SampleExceptionValue(message, code)) { }


    }

    public sealed record SampleExceptionValue(string Message, string Code) : BaseExceptionValue(nameof(SampleException));
}