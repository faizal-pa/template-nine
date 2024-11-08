using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace Template9.Default;

[ExcludeFromCodeCoverage]
public static class CompositionExtensions
{
    /// <summary>
    /// Registers the mapper configuration to the dependency injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection RegisterMapperConfiguration(this IServiceCollection services)
    {
        services.AddSingleton<IAutoMapperConfiguration, ProjectMapperConfiguration>();

        return services;
    }
}
