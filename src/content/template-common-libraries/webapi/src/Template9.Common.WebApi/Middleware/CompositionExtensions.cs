namespace Template9.Common.WebApi.Middleware;

public static class CompositionExtensions
{
    public static IApplicationBuilder UseStandardMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<CurrentContextMiddleware>();

        return app;
    }
}
