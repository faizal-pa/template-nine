using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Template9.Default.Tests;

public abstract class ManagerUnitTest
{
    protected readonly IServiceCollection _services;
    protected readonly IServiceProvider _provider;
    protected readonly IConfigurationRoot _configuration;

    public ManagerUnitTest()
    {
        _services = new ServiceCollection();
        _configuration = GetConfiguration();

        ConfigureLogging(_services);
        ConfigureServices(_services, _configuration);

        _provider = _services.BuildServiceProvider();
    }

    private static IConfigurationRoot GetConfiguration()
    {
        var projectDir = Directory.GetCurrentDirectory();
        var appSettingsPath = Path.Combine(projectDir, "appsettings.json");
        var localAppSettingsPath = Path.Combine(projectDir, "appsettings.local.json");

        var configuration = new ConfigurationBuilder();
        configuration.AddJsonFile(appSettingsPath);

        if (File.Exists(localAppSettingsPath))
            configuration.AddJsonFile(localAppSettingsPath);

        return configuration.Build();
    }

    private static void ConfigureLogging(IServiceCollection services)
    {
        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddDebug();
        });
    }

    /// <summary>
    /// Abstract method allows implementing class to inject dependencies.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    protected abstract void ConfigureServices(IServiceCollection services, IConfiguration configuration);

    /// <summary>
    /// Get service of type T from the IServiceProvider.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>A service object of type T or null if there is no such service.</returns>
    protected T? GetService<T>() => _provider.GetService<T>();

    /// <summary>
    /// Get service of type T from the IServiceProvider.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>A service object of type T.</returns>
    /// <exception cref="InvalidOperationException"></exception>
    protected T GetRequiredService<T>() where T : notnull => _provider.GetRequiredService<T>();
}
