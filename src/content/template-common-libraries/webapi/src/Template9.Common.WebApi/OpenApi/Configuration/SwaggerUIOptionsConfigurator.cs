using System.Diagnostics.CodeAnalysis;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Template9.Common.WebApi.OpenApi.Configuration;

/// <summary>
/// Configures descriptions for each api version in Swagger UI options.
/// </summary>
[ExcludeFromCodeCoverage]
public class SwaggerUIOptionsConfigurator : IConfigureOptions<SwaggerUIOptions>
{
    private readonly OpenApiOptions _options;
    private readonly IApiVersionDescriptionProvider _provider;

    public SwaggerUIOptionsConfigurator(IOptions<OpenApiOptions> options, IApiVersionDescriptionProvider provider)
    {
        _options = options.Value;
        _provider = provider;
    }

    public void Configure(SwaggerUIOptions options)
    {
        options.RoutePrefix = _options.RoutePrefix;

        foreach (var description in _provider.ApiVersionDescriptions)
        {
            var path = string.Format(_options.RouteTemplate, description.GroupName);
            var name = $"{_options.GroupNamePrefix} {description.GroupName.ToLowerInvariant()}";
            options.SwaggerEndpoint(path, name);
        }
    }
}
