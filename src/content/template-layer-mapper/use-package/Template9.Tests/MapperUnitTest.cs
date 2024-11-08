using $(MapperPackage);
namespace Template9.Tests;

public abstract class MapperUnitTest
{
    protected IAutoMapperConfiguration MapperConfiguration;

    protected MapperUnitTest()
    {
        MapperConfiguration = new ProjectMapperConfiguration();
    }
}
