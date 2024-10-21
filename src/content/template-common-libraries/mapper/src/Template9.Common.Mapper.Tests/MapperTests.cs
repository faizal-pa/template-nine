using Template9.Common.Mapper.Extensions;

namespace Template9.Common.Mapper.Tests;

public class MapperTests
{
    private readonly IAutoMapperConfiguration _mapperConfiguration;

    public MapperTests()
    {
        _mapperConfiguration = new TestMapperConfiguration();
    }

    [Fact]
    public void MapSingleObjectTest()
    {
        var expected = new TestMapperSource
        {
            IntPropertySrc = 5,
            DoublePropertySrc = 10.01,
            FloatPropertySrc = 3.14f,
            StringPropertySrc = Guid.NewGuid().ToString(),
            GuidProperty = Guid.NewGuid()
        };

        var actual = expected.MapTo<TestMapperDestination>(_mapperConfiguration);

        actual.ShouldNotBeNull();
        actual.ShouldSatisfyAllConditions(
            () => actual.IgnoreProperty.ShouldBeNull(),
            () => actual.IntPropertyDest.ShouldBe(expected.IntPropertySrc),
            () => actual.DoublePropertyDest.ShouldBe(expected.DoublePropertySrc),
            () => actual.FloatPropertyDest.ShouldBe(expected.FloatPropertySrc),
            () => actual.StringPropertyDest.ShouldBe(expected.StringPropertySrc),
            () => actual.GuidProperty.ShouldBe(expected.GuidProperty),
            () => actual.SomeNumber.ShouldBe(TestMapperProfile.SomeNumber)
        );
    }

    [Fact]
    public void MapEnumerableTest()
    {
        var expectedList = new List<TestMapperSource>
        {
            new() {
                IntPropertySrc = 5,
                DoublePropertySrc = 10.01,
                FloatPropertySrc = 3.14f,
                StringPropertySrc = Guid.NewGuid().ToString(),
                GuidProperty = Guid.NewGuid()
            },
            new() {
                IntPropertySrc = 3,
                DoublePropertySrc = 16.04,
                FloatPropertySrc = 6.66f,
                StringPropertySrc = Guid.NewGuid().ToString(),
                GuidProperty = Guid.NewGuid()
            }
        };

        var actualList = expectedList.MapTo<TestMapperDestination>(_mapperConfiguration);

        actualList.ShouldNotBeNull();
        actualList.ShouldNotBeEmpty();
        actualList.Count().ShouldBe(expectedList.Count);

        for (var i = 0; i < actualList.Count(); i++)
        {
            var actual = actualList.ElementAt(i);
            var expected = expectedList.ElementAt(i);

            actual.ShouldSatisfyAllConditions(
                () => actual.IgnoreProperty.ShouldBeNull(),
                () => actual.IntPropertyDest.ShouldBe(expected.IntPropertySrc),
                () => actual.DoublePropertyDest.ShouldBe(expected.DoublePropertySrc),
                () => actual.FloatPropertyDest.ShouldBe(expected.FloatPropertySrc),
                () => actual.StringPropertyDest.ShouldBe(expected.StringPropertySrc),
                () => actual.GuidProperty.ShouldBe(expected.GuidProperty),
                () => actual.SomeNumber.ShouldBe(TestMapperProfile.SomeNumber)
            );
        }
    }
}
