using Microsoft.AspNetCore.Builder;

namespace WowLogAnalyzer.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        => app.UseMiddleware<WowLogAnalyzer.Middleware.GlobalExceptionMiddleware>();
}