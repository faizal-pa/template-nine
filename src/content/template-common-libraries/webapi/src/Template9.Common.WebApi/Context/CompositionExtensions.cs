using Microsoft.Extensions.DependencyInjection;
using Template9.Common.Abstractions;

namespace Template9.Common.WebApi.Context;

public static class CompositionExtensions
{
    /// <summary>
    /// Adds an implementation of <see cref="IScopeContext"/> to the service collection.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddScopedContext(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IScopeContext, ScopeContext>();

        return services;
    }
}

