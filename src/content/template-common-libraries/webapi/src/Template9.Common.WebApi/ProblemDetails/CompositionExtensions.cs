using Hellang.Middleware.ProblemDetails;
using Hellang.Middleware.ProblemDetails.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Template9.Common.WebApi.ProblemDetails;

public static class CompositionExtensions
{
    /// <summary>
    /// Configures the ASP.NET pipeline to generate problem details responses for unhandled exceptions.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureStandardProblemDetails(this IServiceCollection services)
    {
        ProblemDetailsExtensions.AddProblemDetails(services);
        services.AddProblemDetailsConventions();

        services.ConfigureOptions<ProblemDetailsOptionsConfigurator>();

        return services;
    }

    /// <summary>
    /// Adds the ProblemDetailsMiddleware to the ASP.NET pipeline.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseStandardProblemDetails(this IApplicationBuilder app)
    {
        app.UseProblemDetails();

        return app;
    }
}
