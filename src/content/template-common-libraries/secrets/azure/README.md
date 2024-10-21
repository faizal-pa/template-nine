# Template9.Common.KeyVault

This library contains extension methods for adding configuration providers that read configuration values from Azure KeyVault.

## Developer SetUp

The extension methods in the library use the [`DefaultAzureCredential`](https://learn.microsoft.com/en-us/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet) class. This allows the application to use credentials appropriate to the environment it is running in without changing any code or configuration.

To run the project locally and retrieve values from the Azure KeyVault, you will first need to install the Azure CLI for your operating system, and then login using the command:

```
az login
```

[**Click here to find instructions for installing the Azure CLI**](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)

Once you have successfully authenticated, you can setup and/or run the project and retrieve values from the KeyVault.

## Project Setup

A configuration section should be added to the `appsettings.json` file for the vault name. The default section name is `KeyVault:VaultName`, as shown below.

```json
{
    "KeyVault":
    {
        "VaultName": "MyVaultName"
    }
}
```

Multiple key vault names can be specified by pluralizing the property name and changing the value to an array.

```json
{
    "KeyVault":
    {
        "VaultNames": [
            "MyVaultName1",
            "MyVaultName2"
        ]
    }
}
```

Use the appropriate extension methods where your application sets up configuration providers. The examples below are using `Program.cs` instead of the older `Startup.cs` approach.

```csharp
// to add a single key vault found in the configuration section KeyVault:VaultName
builder.Configuration.ConfigureStandardKeyVault();

// to add multiple key vaults found in the configuration section KeyVault:VaultNames
builder.Configuration.ConfigureStandardKeyVaults();
```

> Exceptions are thrown if values are not found in the expected configuration section for the given extension method.

### Custom Configuration Names

The default configuration section names can be overridden by passing a string parameter to each method that specified the configuration section that has the expected values.

**appsettings.json**
```json
{
    "MyKeyVaultName": "SomeKeyVaultName"
}
```

**Program.cs**
```csharp
builder.Configuration.ConfigureStandardKeyVault("MyKeyVaultName");
```

## Retrieving Values From Azure KeyVaults

Once the configuration provider has been added, values can be retrieved using the same method you would use to retrieve any value from the configuration. Store keys in the format of `SectionName--PropertyName` for easy mapping.