using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Template9.Default;

[ExcludeFromCodeCoverage]
public static class CompositionExtensions
{
    /// <summary>
    /// Registers infrastructure to the dependency injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Register service options
        services.Configure<ServiceOptions>(configuration.GetSection(ServiceOptions.SectionName));

        // Uncomment this section to get service options for use in this method
        // var options = configuration
        //     .GetSection(ServiceOptions.SectionName)
        //     .Get<ServiceOptions>()
        //     ?? new ServiceOptions();

        // Register services
        services.AddScoped<IService, Service>();

        return services;
    }
}
