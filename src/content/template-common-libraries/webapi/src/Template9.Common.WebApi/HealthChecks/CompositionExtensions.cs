using System.Diagnostics.CodeAnalysis;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Template9.Common.WebApi.HealthChecks;

[ExcludeFromCodeCoverage]
public static class CompositionExtensions
{
    /// <summary>
    /// Configures the standard liveness health check for the application.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureStandardHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<HealthCheckConfigurationOptions>(configuration.GetSection(HealthCheckConfigurationOptions.SectionName));
        var options = configuration
            .GetSection(HealthCheckConfigurationOptions.SectionName)
            .Get<HealthCheckConfigurationOptions>()
            ?? new HealthCheckConfigurationOptions();

        services.AddHealthChecks()
            .AddCheck<LivenessHealthCheck>(options.Name);

        return services;
    }

    /// <summary>
    /// Adds a health check endpoint to the <see cref="Microsoft.AspNetCore.Routing.IEndpointRouteBuilder"/> with a standard template and options.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static WebApplication UseStandardHealthChecks(this WebApplication app)
    {
        var options = app.Services.GetRequiredService<IOptions<HealthCheckConfigurationOptions>>().Value;
        return app.UseStandardHealthChecks(options.Pattern);
    }

    /// <summary>
    /// Adds a health check endpoint to the <see cref="Microsoft.AspNetCore.Routing.IEndpointRouteBuilder"/> with the specified template and standard options.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public static WebApplication UseStandardHealthChecks(this WebApplication app, string pattern)
    {
        app.MapHealthChecks(pattern, new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        return app;
    }
}
