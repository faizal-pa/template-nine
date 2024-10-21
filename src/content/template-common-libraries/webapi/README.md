# Template9.Common.WebApi

This package contains extension methods for configuring the Asp.Net pipeline. For consistency, extension methods for `IServiceCollection` have the prefix `ConfigureStandard`, and extension methods for `IApplicationBuilder` or `WebApplication` have the prefix `UseStandard`.

### Sample Usage

Sample recommended usage can be found [here]().

## Template9.Common.WebApi.Configuration

Configures a standard set of options and middleware for WebApi projects.

| Method                   | Description                                                   |
|--------------------------|---------------------------------------------------------------|
| ConfigureStandardOptions | Configures a standard set of options using the options below. |

### Standard Configuration Options

The default value for each property listed below is true. Default values can be changed using a configuration section with the name `StandardConfig`.

| Option                                | Description                                                                                                                            |
|---------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
| AddJsonStringEnumConverter            | Add an instance of `JsonStringEnumConverter` with the default naming policy that allows integer values to the list of JSON converters. |
| AddResponseType400BadRequest          | Add 400 Bad Request as a possible response type to all endpoints.                                                                      |
| AddResponseType406NotAcceptable       | Add 406 Not Acceptable as a possible response type to all endpoints.                                                                   |
| AddResponseType500InternalServerError | Add 500 Internal Server Error as a possible response type to all endpoints.                                                            |
| JsonAllowReadingNumbersFromStrings    | Allow numbers to be deserialized from JSON strings.                                                                                    |
| JsonPropertyNameCaseInsensitive       | Use case-insensitive comparison for property names during JSON deserialization.                                                        |
| JsonPropertyNamingPolicyCamelCase     | Use camel case as the policy used to convert a property's name on an object to another format.                                         |
| RemoveStringOutputFormatters          | Remove `text/plain` from the collection of supported media types for output.                                                           |
| RemoveTextJsonMediaType               | Remove `text/json` from the collection of supported media types for output.                                                            |
| ReturnHttpNotAcceptable               | Return an HTTP 406 Not Acceptable response if no formatter has been selected to format the response.                                   |
| UseLowercaseUrls                      | All generated paths URLs are lowercase.                                                                                                | 

> [!TIP]
> You probably don't want to change any of these without a specific reason.

## Template9.Common.WebApi.Context

Extension method on `IServiceCollection` for adding an implementation of `IScopeContext` to the dependency injection container.

| Method           | Description                                                                                                                     |
|------------------|---------------------------------------------------------------------------------------------------------------------------------|
| AddScopedContext | Adds a instance of [ScopeContext](./src//Template9.Common.WebApi/Context/ScopeContext.cs) to the dependency injection container. |

## Template9.Common.WebApi.HealthChecks

Extension methods for configuring a standard liveness check. Both methods must be used in conjunction.

| Method                        | Description                                                                      |
|-------------------------------|----------------------------------------------------------------------------------|
| ConfigureStandardHealthChecks | Adds a standard liveness check                                                   |
| UseStandardHealthChecks       | Configures health checks to be available at the pattern provided in the options. |

### Health Check Options

Default values can be changed using a configuration section with the name `HealthChecks`.

| Option      | Default Value           | Description                                |
|-------------|-------------------------|--------------------------------------------|
| Description | Application is live     | The description of the health check.       |
| Name        | Standard Liveness Check | The name of the health check.              |
| Pattern     | /_health                | The pattern for the health check endpoint. |

## Template9.Common.WebApi.OpenApi

Extensions methods for configuring the generation of the [OpenApi](https://www.openapis.org/) specification by [Swashbuckle](https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-8.0&tabs=visual-studio).

| Method                      | Description                                                             |
|-----------------------------|-------------------------------------------------------------------------|
| ConfigureStandardSwaggerGen | Configures API Explorer and sets standard Swagger configuration filters | 
| UseStandardSwaggerUi        | Configures the SwaggerUI to be available at `/api/swagger`              |

> [!IMPORTANT]
> The method `UseStandardSwaggerUi` takes an optional boolean argument that indicates whether the SwaggerUI should be added. It defaults to true if not provided. A common approach is to use the environment to decide whether to produce the SwaggerUI, either with `builder.Environment.IsDevelopment()` to only display in the development environment or `!builder.Environment.IsProduction()` to display in all environments except the production environment.

### Swagger Configuration Filters

The following filters are automatically configured when using the supplied extension methods.

| Filter                 | Description                                                                                                 |
|------------------------|-------------------------------------------------------------------------------------------------------------|
| ProblemDetailsFilter   | Adds the `ProblemDetails` model as the schema for all HTTP status code 500 responses.                       |
| SwaggerExcludeFilter   | Removes classes and properties decorated with the `SwaggerExcludeAttribute` from the OpenApi specification. |

### OpenApi Options

The following options can be changed from their default values using a configuration section named `OpenApi`.

| Option          | Default Value                   | Description                                                                  |
|-----------------|---------------------------------|------------------------------------------------------------------------------|
| Title           | The name of the entry assembly. | The title of OpenApi document.                                               |
| Description     | null                            | The description of the OpenApi document.                                     |
| ContactEmail    | null                            | The contact email address for the OpenApi document.                          |
| ContactUrl      | null                            | The contact url address for the OpenApi document.                            |
| ContactName     | null                            | The contact name address for the OpenApi document.                           |
| RouteTemplate   | /api/{0}/openapi.json           | The route template for the generated OpenApi specification for each version. |
| RoutePrefix     | api/swagger                     | The route prefix where the SwaggerUI can be accessed.                        |
| GroupNamePrefix | The name of the entry assembly. | The group name for each version of the OpenApi specification.                |

## Template9.Common.WebApi.ProblemDetails

Extension methods for configuring [Problem Details](https://datatracker.ietf.org/doc/html/rfc7807) using [`Hellang.Middleware.ProblemDetails`](https://www.nuget.org/packages/Hellang.Middleware.ProblemDetails).

| Method                          | Description                                                           |
|---------------------------------|-----------------------------------------------------------------------|
| ConfigureStandardProblemDetails | Configures `Hellang.Middleware.ProblemDetails.ProblemDetailsOptions`. |
| UseStandardProblemDetails       | Adds the `ProblemDetailsMiddleware` to the application pipeline.      |

### Problem Details Options

The following options are set during problem details configuration.

| Option                     | Value                                                               |
|----------------------------|---------------------------------------------------------------------|
| IncludeExceptionDetails    | Only in development environments.                                   |
| Map<Template9BaseException> | Adds a function to map `Template9BaseException` to `ProblemDetails`. |
| MapToStatusCode            | Maps common exceptions to common HTTP status codes.                 |

The following exceptions are mapped to the corresponding status codes:

| Exception               | StatusCode                |
|-------------------------|---------------------------|
| NotImplementedException | 501 Not Implemented       |
| HttpRequestException    | 503 Service Unavailable   |
| Exception               | 500 Internal Server Error |
