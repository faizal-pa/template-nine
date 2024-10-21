namespace Template9.Common.Extensions.Tests;

public class DateTimeOffsetExtensionsTests
{
    private static readonly DateTimeOffset _now = (DateTimeOffset)DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);

    [Fact]
    public void GetEndOfDayTest()
    {
        var endOfDay = _now.GetEndOfDay();

        var expected = "23:59:59:999";
        var actual = string.Join(":", endOfDay.Hour, endOfDay.Minute, endOfDay.Second, endOfDay.Millisecond);

        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetStartOfDayTest()
    {
        var startOfDay = _now.GetStartOfDay();

        var expected = "0:0:0:0";
        var actual = string.Join(":", startOfDay.Hour, startOfDay.Minute, startOfDay.Second, startOfDay.Millisecond);

        actual.ShouldBe(expected);
    }
}
