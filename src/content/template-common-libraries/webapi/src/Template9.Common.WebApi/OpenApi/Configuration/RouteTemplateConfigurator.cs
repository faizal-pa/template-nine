using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Template9.Common.WebApi.OpenApi.Configuration;

/// <summary>
/// Configures the route template for the Swagger UI.
/// </summary>
[ExcludeFromCodeCoverage]
public class RouteTemplateConfigurator : IConfigureOptions<SwaggerOptions>
{
    private readonly OpenApiOptions _options;

    public RouteTemplateConfigurator(IOptions<OpenApiOptions> options)
    {
        _options = options.Value;
    }

    public void Configure(SwaggerOptions options)
    {
        options.RouteTemplate = string.Format(_options.RouteTemplate, "{documentName}");
    }
}
