using AutoMapper;
using Template9.Default.Profiles;

namespace Template9.Default;

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
