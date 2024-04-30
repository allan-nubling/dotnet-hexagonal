
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.API.v1.Controllers;
public class HttpResponseExceptionFilter : IActionFilter
{

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is HttpException httpResponseException)
        {
            context.Result = new ObjectResult(httpResponseException.Value)
            {
                StatusCode = httpResponseException.StatusCode
            };

            context.ExceptionHandled = true;
        }

        if (context.Exception is Exception ex)
        {
            context.Result = new ObjectResult(new ServerExceptionValue("Server", ex.Message))
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;

        }
    }
}
