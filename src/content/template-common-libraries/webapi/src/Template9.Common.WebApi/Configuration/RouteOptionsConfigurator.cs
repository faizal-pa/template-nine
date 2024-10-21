using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;

namespace Template9.Common.WebApi.Configuration;

/// <summary>
/// Configures the route options for the application.
/// </summary>
[ExcludeFromCodeCoverage]
public class RouteOptionsConfigurator : IPostConfigureOptions<RouteOptions>
{
    private readonly StandardConfigOptions _options;

    public RouteOptionsConfigurator(IOptions<StandardConfigOptions> standardConfigOptions)
    {
        _options = standardConfigOptions.Value;
    }

    public void PostConfigure(string? name, RouteOptions options)
    {
        if (_options.UseLowercaseUrls)
            options.LowercaseUrls = true;
    }
}
