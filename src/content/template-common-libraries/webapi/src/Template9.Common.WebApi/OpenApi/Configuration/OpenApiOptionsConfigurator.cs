using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.Options;

namespace Template9.Common.WebApi.OpenApi.Configuration;

/// <summary>
/// Configures the OpenApiOptions instance by providing default values for Title and GroupNamePrefix.
/// </summary>
[ExcludeFromCodeCoverage]
public class OpenApiOptionsConfigurator : IPostConfigureOptions<OpenApiOptions>
{
    public void PostConfigure(string? name, OpenApiOptions options)
    {
        options.Title ??= Assembly.GetEntryAssembly()?.GetName().Name ?? "Unknown Calling Assembly";
        options.GroupNamePrefix ??= options.Title;
    }
}
