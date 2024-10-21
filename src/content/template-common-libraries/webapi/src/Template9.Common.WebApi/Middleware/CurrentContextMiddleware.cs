using Microsoft.AspNetCore.Http;
using Template9.Common.Abstractions;

namespace Template9.Common.WebApi.Middleware;

public class CurrentContextMiddleware
{
    private readonly RequestDelegate _next;

    public CurrentContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Headers.TryGetValue("X-Correlation-Id", out var correlationId))
        {
            if (Guid.TryParse(correlationId, out var guid))
                CurrentContext.CorrelationId = guid;
        }

        await _next(context);
    }
}
