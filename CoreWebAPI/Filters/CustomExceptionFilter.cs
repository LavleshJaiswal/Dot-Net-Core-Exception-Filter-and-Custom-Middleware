﻿
namespace CoreWebAPI.Filters;
public class CustomExceptionFilter : IAsyncExceptionFilter
{

    public Task OnExceptionAsync(ExceptionContext context)
    {

        var exception = context.Exception;
        var respoinse = new
        {
            Message = "Something went wrong",
            StatusCode = 500,
            Details = exception.Message
        };

        context.Result = new BadRequestObjectResult(respoinse);
        context.ExceptionHandled = true;
        return Task.CompletedTask;
    }
}
