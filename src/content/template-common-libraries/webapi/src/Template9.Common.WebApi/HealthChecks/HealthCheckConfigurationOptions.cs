using System.Diagnostics.CodeAnalysis;

namespace Template9.Common.WebApi.HealthChecks;

/// <summary>
/// Options for configuring the standard health check.
/// </summary>
[ExcludeFromCodeCoverage]
public class HealthCheckConfigurationOptions
{
    /// <summary>
    /// The name of the health check configuration section.
    /// </summary>
    public static readonly string SectionName = "HealthChecks";

    /// <summary>
    /// Gets or sets the description of the health check.
    /// </summary>
    public string Description { get; set; } = "Application is live";

    /// <summary>
    /// Gets or sets the name of the health check.
    /// </summary>
    public string Name { get; set; } = "Standard Liveness Check";

    /// <summary>
    /// Gets or sets the pattern for the health check endpoint.
    /// </summary>
    public string Pattern { get; set; } = "/_health";
}
