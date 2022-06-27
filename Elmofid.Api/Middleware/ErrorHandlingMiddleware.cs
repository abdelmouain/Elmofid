using System.Net;
using System.Text.Json;

namespace Elmofid.Api.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        const HttpStatusCode code = HttpStatusCode.InternalServerError; //500 if unexpected
        var problemDetails = new
        {
            Type = exception.GetType().FullName,
            Title = exception.Message,
            Status = (int)HttpStatusCode.InternalServerError,
            DateTime = DateTime.UtcNow,
            Inner = exception.InnerException?.Message,
        };
        var result = JsonSerializer.Serialize(problemDetails);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}