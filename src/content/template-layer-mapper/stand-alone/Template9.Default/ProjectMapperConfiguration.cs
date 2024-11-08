using AutoMapper;
using Template9.Default.Profiles;

namespace Template9.Default;

public class ProjectMapperConfiguration : IAutoMapperConfiguration
{
    public IMapper Mapper { get; protected set; }

    public ProjectMapperConfiguration()
    {
        var config = ConfigureMapper();
        config.AssertConfigurationIsValid();

        Mapper = config.CreateMapper();
    }

    private MapperConfiguration ConfigureMapper()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MapperProfile>();
        });
    }
}
