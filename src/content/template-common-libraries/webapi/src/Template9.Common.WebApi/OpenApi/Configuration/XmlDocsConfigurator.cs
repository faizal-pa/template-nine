using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Template9.Common.WebApi.OpenApi.Configuration;

/// <summary>
/// Configures xml docs for use in OpenApi.
/// </summary>
[ExcludeFromCodeCoverage]
public class XmlDocsConfigurator : IConfigureNamedOptions<SwaggerGenOptions>
{
    private static readonly IEnumerable<string> _suffixes = [ "", ".Dto", ".Dtos" ];

    private readonly ApplicationPartManager _partManager;

    public XmlDocsConfigurator(ApplicationPartManager partManager)
    {
        _partManager = partManager;
    }

    public void Configure(string? name, SwaggerGenOptions options) => this.Configure(options);

    public void Configure(SwaggerGenOptions options)
    {
        var assemblies = _partManager.ApplicationParts
            .OfType<AssemblyPart>()
            .Select(part => part.Assembly.GetName().Name)
            .ToHashSet();

        foreach (var assembly in assemblies)
        {
            foreach (var suffix in _suffixes)
            {
                var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{assembly}{suffix}.xml");
                if (File.Exists(xmlPath)) options.IncludeXmlComments(xmlPath);
            }
        }
    }
}
