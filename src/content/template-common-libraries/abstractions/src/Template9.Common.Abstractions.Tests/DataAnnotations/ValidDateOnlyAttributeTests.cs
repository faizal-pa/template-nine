using Template9.Common.Abstractions.DataAnnotations;
using Template9.Common.Testing;

namespace Template9.Common.Abstractions.Tests.DataAnnotations;

public class ValidDateOnlyAttributeTests
{
    [Fact]
    public void ValidDateOnlySuccess()
    {
        var model = new ModelWithDateOnly
        {
            SpecialDateNameForMyModel = new DateOnly(2021, 1, 1)
        };

        var results = ModelValidator.Validate(model);
        results.ShouldBeEmpty();
    }

    [Fact]
    public void ValidDateOnlyFailure()
    {
        var model = new ModelWithDateOnly();

        var results = ModelValidator.Validate(model);
        results.Count.ShouldBe(1);

        results.First().MemberNames.Count().ShouldBe(1);
        results.First().MemberNames.First().ShouldBe(nameof(ModelWithDateOnly.SpecialDateNameForMyModel));
    }
}

public class ModelWithDateOnly
{
    [ValidDateOnly]
    public DateOnly SpecialDateNameForMyModel { get; set; }
}
