using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace Template9.Common.Extensions;

[ExcludeFromCodeCoverage]
public static class IConfigurationExtensions
{
    private static readonly string toolVariableName = "TOOL";

    /// <summary>
    /// Returns true if the current application is running in the context of a tool (e.g. Swagger).
    /// </summary>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static bool IsToolExecuting(this IConfiguration configuration)
    {
        return !string.IsNullOrWhiteSpace(configuration.GetValue<string>(toolVariableName));
    }

    /// <summary>
    /// Returns the current tool being executed.
    /// </summary>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static Tool ExecutingTool(this IConfiguration configuration)
    {
        var tool = configuration.GetValue<string>(toolVariableName);
        if (string.IsNullOrEmpty(tool)) return Tool.None;
        return tool.ToEnum(Tool.Unknown);
    }
}
