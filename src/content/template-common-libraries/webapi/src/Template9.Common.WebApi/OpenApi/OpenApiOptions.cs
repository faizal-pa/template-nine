using System.Diagnostics.CodeAnalysis;
using Microsoft.OpenApi.Models;

namespace Template9.Common.WebApi.OpenApi;

/// <summary>
/// Options for configuring OpenApi generation.
/// </summary>
[ExcludeFromCodeCoverage]
public class OpenApiOptions
{
    /// <summary>
    /// The name of the section in the configuration file that contains the OpenApi options.
    /// </summary>
    public static readonly string SectionName = "OpenApi";

    /// <summary>
    /// The title of the OpenApi document.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// The description of the OpenApi document.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The contact email for the OpenApi document.
    /// </summary>
    public string? ContactEmail { get; set; }

    /// <summary>
    /// The contact URL for the OpenApi document.
    /// </summary>
    public string? ContactUrl { get; set; }

    /// <summary>
    /// The contact name for the OpenApi document.
    /// </summary>
    public string? ContactName { get; set; }

    /// <summary>
    /// The route template for the SwaggerUI document.
    /// </summary>
    public string RouteTemplate { get; set; } = "/api/{0}/openapi.json";

    /// <summary>
    /// The route prefix for the SwaggerUI document.
    /// </summary>
    public string RoutePrefix { get; set; } = "api/swagger";

    /// <summary>
    /// The group name prefix for the SwaggerUI document.
    /// </summary>
    public string GroupNamePrefix { get; set; } = null!;
}

[ExcludeFromCodeCoverage]
public static class OpenApiOptionsExtensions
{
    /// <summary>
    /// Creates an <see cref="OpenApiContact"/> object from the <see cref="OpenApiOptions"/> instance.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public static OpenApiContact? ContactInfo(this OpenApiOptions options)
    {
        if (options.ContactEmail is null && options.ContactUrl is null && options.ContactName is null)
        {
            return null;
        }

        var contact = new OpenApiContact();

        if (options.ContactName is not null)
            contact.Name = options.ContactName;

        if (options.ContactEmail is not null)
            contact.Email = options.ContactEmail;

        if (options.ContactUrl is not null && Uri.TryCreate(options.ContactUrl, UriKind.Absolute, out var url))
            contact.Url = url;

        return contact;
    }
}
