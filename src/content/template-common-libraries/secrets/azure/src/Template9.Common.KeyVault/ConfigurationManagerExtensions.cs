using System.Diagnostics.CodeAnalysis;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Template9.Common.Exceptions;

namespace Template9.Common.KeyVault;

[ExcludeFromCodeCoverage]
public static class ConfigurationManagerExtensions
{
    /// <summary>
    /// Default configuration section name for the key vault name.
    /// </summary>
    private static readonly string DefaultKeyVaultSection = "KeyVault:VaultName";

    /// <summary>
    /// Default configuration section name for the key vault names.
    /// </summary>
    private static readonly string DefaultKeyVaultsSection = "KeyVault:VaultNames";

    /// <summary>
    /// Adds a configuration provider that reads configuration values from the Azure KeyVault.
    /// </summary>
    /// <param name="configuration"></param>
    /// <remarks>Reads the key vault name from the configuration using the default section name KeyVault:VaultName</remarks>
    public static ConfigurationManager ConfigureStandardKeyVault(this ConfigurationManager configuration)
    {
        return configuration.ConfigureStandardKeyVault(DefaultKeyVaultSection);
    }

    /// <summary>
    /// Adds a configuration provider that reads configuration values from the Azure KeyVault.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="sectionName"></param>
    /// <remarks>Reads the key vault name from the configuration using the specified section name.</remarks>
    public static ConfigurationManager ConfigureStandardKeyVault(this ConfigurationManager configuration, string sectionName)
    {
        var vaultName = configuration.GetValue<string>(sectionName)
            ?? throw new ConfigurationException($"Vault name not found in configuration section {sectionName}");

        return configuration.AddKeyVault(vaultName);
    }

    /// <summary>
    /// Adds a configuration provider that reads configuration values from the Azure KeyVault for each vault name in the configuration.
    /// </summary>
    /// <param name="configuration"></param>
    /// <remarks>Vault names are read from the configuration section KeyVault:VaultNames.</remarks>
    public static ConfigurationManager ConfigureStandardKeyVaults(this ConfigurationManager configuration)
    {
        return configuration.ConfigureStandardKeyVaults(DefaultKeyVaultsSection);
    }

    /// <summary>
    /// Adds a configuration provider that reads configuration values from the Azure KeyVault for each vault name found in the section name provided.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="sectionName"></param>
    public static ConfigurationManager ConfigureStandardKeyVaults(this ConfigurationManager configuration, string sectionName)
    {
        var vaultNames = configuration.GetValue<string[]>(sectionName)
            ?? throw new ConfigurationException($"Vault names not found in configuration section {sectionName}");

        foreach (var vaultName in vaultNames)
        {
            configuration.AddKeyVault(vaultName);
        }

        return configuration;
    }

    private static ConfigurationManager AddKeyVault(this ConfigurationManager configuration, string vaultName)
    {
        var vaultUrl = new Uri($"https://{vaultName}.vault.azure.net");
        configuration.AddAzureKeyVault(vaultUrl, new DefaultAzureCredential());
        return configuration;
    }
}

