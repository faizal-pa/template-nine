using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Template9.Default.Tests;

public class UnitTest1 : ManagerUnitTest
{
    private readonly IManager _manager;

    public UnitTest1()
    {
        _manager = GetRequiredService<IManager>();
    }

    protected override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IManager, Manager>();
    }

    [Fact]
    public void Test1()
    {
        // write tests here
    }
}