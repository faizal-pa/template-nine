using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Template9.Common.Logging;

[ExcludeFromCodeCoverage]
public static class CompositionExtensions
{
    /// <summary>
    /// Configures the standard logging for the application.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static WebApplicationBuilder ConfigureStandardLogging(this WebApplicationBuilder builder)
    {
        // Select the minimum log level for Microsoft and System packages based
        // on the environment.
        var msLogEventLevel = builder.Environment.IsDevelopment()
            ? LogEventLevel.Information
            : LogEventLevel.Warning;

        // Create the logger.
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", msLogEventLevel)
            .MinimumLevel.Override("System", msLogEventLevel)
            .MinimumLevel.Override("Microsoft.AspNetCore", msLogEventLevel)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        // Add the logger to the builder.
        builder.Host.UseSerilog();

        return builder;
    }
}
