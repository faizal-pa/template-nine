using AutoMapper;

namespace Template9.Common.Mapper.Tests;

public class TestMapperConfiguration : DomainMapperConfiguration
{
    protected override MapperConfiguration ConfigureMapper()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TestMapperProfile>();
        });
    }
}
