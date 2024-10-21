using System.Diagnostics.CodeAnalysis;

using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Template9.Common.WebApi.OpenApi.Configuration;

/// <summary>
/// Configures the SwaggerGenOptions instance with the API version information.
/// </summary>
[ExcludeFromCodeCoverage]
public class ApiVersionsConfigurator : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    private readonly OpenApiOptions _options;

    public ApiVersionsConfigurator(IApiVersionDescriptionProvider provider, IOptions<OpenApiOptions> options)
    {
        _provider = provider;
        _options = options.Value;
    }

    /// <summary>
    /// Configures the <see cref="SwaggerGenOptions"/> instance.
    /// </summary>
    /// <param name="options"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Configure(SwaggerGenOptions options)
    {        
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }
    }

    /// <summary>
    /// Creates the OpenApiInfo object for the specified API version description
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
    {
        var info = new OpenApiInfo
        {
            Title = _options.Title,
            Description = _options.Description,
            Contact = _options.ContactInfo(),
            Version = description.ApiVersion.ToString()
        };

        if (description.IsDeprecated)
        {
            info.Description += " This API version has been deprecated.";
        }

        return info;
    }
}
