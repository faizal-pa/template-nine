using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Template9.Common.WebApi.Configuration;

/// <summary>
/// Configures the <see cref="JsonOptions"/> for the application.
/// </summary>
[ExcludeFromCodeCoverage]
public class JsonOptionsConfigurator : IPostConfigureOptions<JsonOptions>
{
    private readonly StandardConfigOptions _options;

    public JsonOptionsConfigurator(IOptions<StandardConfigOptions> options)
    {
        _options = options.Value;
    }

    public void PostConfigure(string? name, JsonOptions options)
    {
        if (_options.JsonPropertyNameCaseInsensitive)
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;

        if (_options.JsonPropertyNamingPolicyCamelCase)
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

        if (_options.AddJsonStringEnumConverter)
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        if (_options.JsonAllowReadingNumbersFromStrings)
            options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
    }
}
