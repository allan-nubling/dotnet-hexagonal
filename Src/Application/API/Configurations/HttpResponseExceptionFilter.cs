
using Domain.Enums;
using Domain.Exceptions;
using Domain.Exceptions.Bases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace Application.API.Configurations.Filters;
/// <inheritdoc/>
public class HttpResponseExceptionFilter : IActionFilter
{
    /// <inheritdoc/>
    public void OnActionExecuting(ActionExecutingContext context)
    {
    }
    /// <inheritdoc/>
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is BaseException handledException)
        {
            context.Result = new ObjectResult(handledException.Value)
            {
                StatusCode = handledException switch
                {
                    AdapterException => StatusCodes.Status502BadGateway,
                    DomainException => StatusCodes.Status400BadRequest,
                    ForbiddenException => StatusCodes.Status403Forbidden,
                    _ => StatusCodes.Status500InternalServerError
                }
            };
            context.ExceptionHandled = true;
            return;
        }
        if (context.Exception is not null)
        {
            context.Result = new ObjectResult(new UnexpectedInternalException("Server", ExceptionCode.SE000).Value)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}
