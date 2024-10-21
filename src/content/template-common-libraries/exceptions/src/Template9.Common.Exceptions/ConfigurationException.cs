using System.Diagnostics.CodeAnalysis;

namespace Template9.Common.Exceptions;

/// <summary>
/// The exception thrown when required configurations are invalid or missing from the application configuration provider.
/// </summary>
[ExcludeFromCodeCoverage]
public class ConfigurationException : Exception
{
    public ConfigurationException() : base()
    { }

    public ConfigurationException(string message) : base(message)
    { }

    public ConfigurationException(string message, Exception innerException) : base(message, innerException)
    { }
}
