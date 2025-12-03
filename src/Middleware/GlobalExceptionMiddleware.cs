using System.Net;
using System.Text.Json;

namespace WowLogAnalyzer.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        var status = ex switch
        {
            ArgumentNullException        => HttpStatusCode.BadRequest,
            ArgumentException            => HttpStatusCode.BadRequest,
            KeyNotFoundException         => HttpStatusCode.NotFound,
            UnauthorizedAccessException  => HttpStatusCode.Unauthorized,

            // custom domain exceptions go here:
            // DomainValidationException   => HttpStatusCode.UnprocessableEntity,
            // ForbiddenException          => HttpStatusCode.Forbidden,

            _ => HttpStatusCode.InternalServerError
        };

        context.Response.StatusCode = (int)status;

        var errorResponse = new
        {
            type = "https://httpstatuses.com/" + (int)status,
            title = ex.GetType().Name,
            status = (int)status,
            traceId = context.TraceIdentifier,
            message = ex.Message
        };

        // Use System.Text.Json default options
        var json = JsonSerializer.Serialize(errorResponse);

        await context.Response.WriteAsync(json);
    }
}
