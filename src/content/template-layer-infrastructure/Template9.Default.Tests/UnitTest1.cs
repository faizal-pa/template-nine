namespace Template9.Default.Tests;

[Collection("IntegrationTest")]
public class UnitTest1
{
    private readonly IService _service;

    public UnitTest1(TestFixture fixture)
    {
        _service = fixture.GetRequiredService<IService>();
    }

    [Fact]
    public void Test1()
    {
        // write tests here
    }
}