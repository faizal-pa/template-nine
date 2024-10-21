using Template9;

namespace Template9.Tests;

[Collection("IntegrationTest")]
public class UnitTest1
{
    private readonly IClientInterface _client;

    public UnitTest1(TestFixture fixture)
    {
        _client = fixture.GetRequiredService<IClientInterface>();
    }

    [Fact]
    public void Test1()
    {
        // write tests here
    }
}
