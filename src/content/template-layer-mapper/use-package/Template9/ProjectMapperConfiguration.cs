using AutoMapper;
using $(MapperPackage);
using Template9.Profiles;

namespace Template9;

public class ProjectMapperConfiguration : DomainMapperConfiguration
{
    protected override MapperConfiguration ConfigureMapper()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MapperProfile>();
        });
    }
}
