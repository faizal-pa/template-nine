using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Template9.Common.WebApi.Configuration;

[ExcludeFromCodeCoverage]
public class StandardConfigOptions
{
    public static readonly string SectionName = "StandardConfig";

    /// <summary>
    /// Get or set a boolean value indicating whether to add an instance of the <see cref="JsonStringEnumConverter"/> class with the default naming policy that allows integer values to the list of converters for <see cref="JsonSerializerOptions"/>.
    /// The default value is true.
    /// </summary>
    public bool AddJsonStringEnumConverter { get; set; } = true;

    /// <summary>
    /// Gets or sets a boolean value indicating whether to add HTTP status code 400 Bad Request to the list of possible HTTP response types for all endpoints.
    /// The default value is true.
    /// </summary>
    public bool AddResponseType400BadRequest { get; set; } = true;

    /// <summary>
    /// Gets or sets a boolean value indicating whether to add HTTP status code 406 Not Acceptable to the list of possible HTTP response types for all endpoints.
    /// The default value is true.
    /// </summary>
    public bool AddResponseType406NotAcceptable { get; set; } = true;

    /// <summary>
    /// Gets or sets a boolean value indicating whether to add HTTP status code 500 Internal Server Error to the list of possible HTTP response types for all endpoints.
    /// The default value is true.
    /// </summary>
    public bool AddResponseType500InternalServerError { get; set; } = true;

    /// <summary>
    /// Gets or sets a boolean value indicating whether numbers can be read from <see cref="JsonTokenType.String"/> tokens.
    /// Does not prevent numbers from being read from <see cref="JsonTokenType.Number"/> token.
    /// The default value is true.
    /// </summary>
    public bool JsonAllowReadingNumbersFromStrings { get; set; } = true;

    /// <summary>
    /// Gets or sets a boolean value indicating whether a property's name uses a case-insensitive comparison during deserialization.
    /// The default value is true.
    /// </summary>
    public bool JsonPropertyNameCaseInsensitive { get; set; } = true;

    /// <summary>
    /// Gets or sets a boolean value indicating whether to use camel case as the policy used to convert a property's name on an object to another format.
    /// The default value is true.
    /// </summary>
    public bool JsonPropertyNamingPolicyCamelCase { get; set; } = true;

    /// <summary>
    /// Gets or sets a boolean value indicating whether to remove text/plain from the collection of supported media types for output.
    /// It is generally accepted that text/plain is not an appropriate output type for REST apis.
    /// The default value is true.
    /// </summary>
    public bool RemoveStringOutputFormatters { get; set; } = true;

    /// <summary>
    /// Gets or sets a boolean value indicating whether to remove text/json from the collection of supported media types for output.
    /// It is generally accepted that application/json is preferred over text/json for REST apis.
    /// The default value is true.
    /// </summary>
    public bool RemoveTextJsonMediaType { get; set; } = true;

    /// <summary>
    /// Gets or sets a boolean value indicating whether an HTTP 406 Not Acceptable response will be returned if no formatter has been selected to format the response.
    /// The default value is true.
    /// </summary>
    public bool ReturnHttpNotAcceptable { get; set; } = true;

    /// <summary>
    /// Gets or sets a boolean value indicating whether all generated paths URLs are lowercase.
    /// The default value is true.
    /// </summary>
    public bool UseLowercaseUrls { get; set; } = true;
}
