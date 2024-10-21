using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Template9.Common.WebApi.Configuration;

public static class CompositionExtensions
{
    /// <summary>
    /// Configures the standard options for the web api.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureStandardOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<StandardConfigOptions>(configuration.GetSection(StandardConfigOptions.SectionName));

        services.ConfigureOptions<RouteOptionsConfigurator>();
        services.ConfigureOptions<MvcOptionsConfigurator>();
        services.ConfigureOptions<JsonOptionsConfigurator>();

        return services;
    }
}
