using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

namespace Template9.Common.WebApi.HealthChecks;

/// <summary>
/// A health check that returns healthy when the application is live.
/// </summary>
[ExcludeFromCodeCoverage]
public class LivenessHealthCheck : IHealthCheck
{
    private readonly HealthCheckConfigurationOptions _options;

    public LivenessHealthCheck(IOptions<HealthCheckConfigurationOptions> options)
    {
        _options = options.Value;
    }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(HealthCheckResult.Healthy(_options.Description));
    }
}
