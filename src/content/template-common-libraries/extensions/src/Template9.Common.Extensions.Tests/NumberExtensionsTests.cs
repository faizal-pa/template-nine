namespace Template9.Common.Extensions.Tests;

public class NumberExtensionsTests
{
    [Theory]
    [InlineData(199, false)]
    [InlineData(300, false)]
    [InlineData(200, true)]
    [InlineData(299, true)]
    [InlineData(500, false)]
    public void IsSuccessStatusCodeTests(int value, bool expected)
    {
        value.IsSuccessStatusCode().ShouldBe(expected);
    }

    [Theory]
    [InlineData(15, 10, 20, true)]
    [InlineData(15, 20, 10, false)]
    [InlineData(15, 20, 30, false)]
    [InlineData(35, 20, 30, false)]
    public void IsBetweenTests(int value, int lowerBound, int upperBound, bool expected)
    {
        value.IsBetween(lowerBound, upperBound).ShouldBe(expected);
    }
}
