namespace Template9.Default.Tests;

public abstract class MapperUnitTest
{
    protected IAutoMapperConfiguration MapperConfiguration;

    protected MapperUnitTest()
    {
        MapperConfiguration = new ProjectMapperConfiguration();
    }
}
