using AutoMapper;
using Template9.Common.Mapper.Extensions;

namespace Template9.Common.Mapper.Tests;

public class TestMapperProfile : Profile
{
    public const int SomeNumber = 3;

    public TestMapperProfile()
    {
        CreateMap<TestMapperSource, TestMapperDestination>()
            .Ignore(dest => dest.IgnoreProperty)
            .Ignore(dest => dest.SomeNumber)
            .AndMap(src => src.IntPropertySrc, dest => dest.IntPropertyDest)
            .AndMap(src => src.DoublePropertySrc, dest => dest.DoublePropertyDest)
            .AndMap(src => src.FloatPropertySrc, dest => dest.FloatPropertyDest)
            .AndMap(src => src.StringPropertySrc, dest => dest.StringPropertyDest)
            .AfterMap((src, dest) =>
            {
                dest.SomeNumber = SomeNumber;
            });
    }
}
