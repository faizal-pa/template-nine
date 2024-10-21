using System.Diagnostics.CodeAnalysis;
using Kralizek.Extensions.Configuration.Internal;
using Microsoft.Extensions.Configuration;
using Template9.Common.Extensions;

namespace Template9.Common.Secrets;

[ExcludeFromCodeCoverage]
public static class CompositionExtensions
{
    private static readonly Dictionary<SupportedEnvironments, IEnumerable<string>> _environmentMap = new()
    {
        [SupportedEnvironments.Local] = ["Local"],
        [SupportedEnvironments.Development] = ["Development", "Dev"],
        [SupportedEnvironments.Production] = ["Production", "Prod"],
        [SupportedEnvironments.QA] = ["QA"],
        [SupportedEnvironments.Staging] = ["Staging", "Stage"],
    };

    /// <summary>
    /// Configures the AWS Secrets Manager with the standard key generator for the given environment name.
    /// </summary>
    /// <param name="config"></param>
    /// <param name="environmentName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static IConfigurationManager ConfigureStandardSecretsManager(this IConfigurationManager config, string environmentName)
    {
        if (string.IsNullOrWhiteSpace(environmentName))
            throw new ArgumentException("Environment name must be provided.", nameof(environmentName));

        var environment = environmentName.ToEnum(SupportedEnvironments.None);
        var prefixes = (environment == SupportedEnvironments.None)
            ? [environmentName]
            : _environmentMap[environment].ToArray();

        config.AddSecretsManager(configurator: options =>
        {
            options.KeyGenerator = (entry, key) =>
            {
                var prefix = prefixes.FirstOrDefault(p => key.StartsWith(p, StringComparison.OrdinalIgnoreCase));

                return (prefix != null)
                    ? key[(prefix.Length + 1)..]
                    : key;
            };
        });

        return config;
    }

    /// <summary>
    /// Configures the AWS Secrets Manager using the provided configuration action.
    /// </summary>
    /// <param name="config"></param>
    /// <param name="configure"></param>
    /// <returns></returns>
    public static IConfigurationManager ConfigureStandardSecretsManager(this IConfigurationManager config, Action<SecretsManagerConfigurationProviderOptions> configure)
    {
        config.AddSecretsManager(configurator: configure);
        return config;
    }
}
