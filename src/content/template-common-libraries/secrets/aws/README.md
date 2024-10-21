# Template9.Common.Secrets

Provides extension methods on `IConfigurationManager` for configuring AWS Secrets Manager as a configuration provider using conventions.

| Method                          | Parameter                | Description                                            |
|---------------------------------|--------------------------|--------------------------------------------------------|
| ConfigureStandardSecretsManager | string environment name  | Uses the default keygen based on the environment name. |
| ConfigureStandardSecretsManager | action for configuration | Provide a custom configuration for the project.        |

# Conventions

Secrets can be divided into groups in the secrets manager using a naming convention based on the environment name and the section name.

Given this sample options class:

```csharp
public class SampleOptions
{

    /// <summary>
    /// The name of the configuration section to map properties from.
    /// </summary>
    public static readonly string SectionName = "Sample";

    /// <summary>
    /// Sample connection string for database.
    /// </summary>
    public string ConnectionString { get; set; } = null!;

    /// <summary>
    /// URL of a sample service.
    /// </summary>
    public Uri ServiceUrl { get; set; } = null!;
}
```

Then the configuration provider should be added:
```
builder.Configuration.ConfigureStandardSecretsManager(builder.Environment.EnvironmentName);
```

After which an instance of `IOptions<SampleOptions>` with values populated from the registered configuration providers can be added to the dependency injection container.

```csharp
builder.Services.Configure<SampleOptions>(configuration.GetSection(SampleOptions.SectionName));
```

## Naming Conventions

AWS Secrets Manager does not allow the use of the colon (`:`), which is the character commonly used to support hierarchical naming to represent nested sections in configuration providers. Given that it does support the forward slash (`/`), use the following naming convention to to represent nested sections and hierarchies in AWS Secrets Manager to support the scenario above:

| Environment | Property         | Secret Name  | Secret Key       |
|-------------|------------------|--------------|------------------|
| Development | ConnectionString | Dev/Sample   | ConnectionString |
| Development | ServiceUrl       | Dev/Sample   | ServiceUrl       |
| QA          | ConnectionString | QA/Sample    | ConnectionString |
| QA          | ServiceUrl       | QA/Sample    | ServiceUrl       |
| Production  | ConnectionString | Prod/Sample  | ConnectionString |
| Production  | ServiceUrl       | Prod/Sample  | ServiceUrl       |
| Staging     | ConnectionString | Stage/Sample | ConnectionString |
| Staging     | ServiceUrl       | Stage/Sample | ServiceUrl       |

## Dependencies

This packages depends on [Kralizek.Extensions.Configuration.AWSSecretsManager](https://www.nuget.org/packages/Kralizek.Extensions.Configuration.AWSSecretsManager)