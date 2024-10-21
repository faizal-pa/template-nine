using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Template9.Default.Tests;

public class UnitTest1 : EngineUnitTest
{
    private readonly IEngine _engine;

    public UnitTest1()
    {
        _engine = GetRequiredService<IEngine>();
    }

    protected override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IEngine, Engine>();
    }

    [Fact]
    public void Test1()
    {
        // write tests here
    }
}