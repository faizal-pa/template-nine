using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Template9.Default;

[ExcludeFromCodeCoverage]
public static class CompositionExtensions
{
    /// <summary>
    /// Registers engines to the dependency injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection RegisterEngines(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IEngine, Engine>();

        return services;
    }
}
