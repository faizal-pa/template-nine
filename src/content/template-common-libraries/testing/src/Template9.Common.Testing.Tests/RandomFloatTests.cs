namespace Template9.Common.Testing.Tests;

public class RandomFloatTests
{
    [Fact]
    public void ThrowsExceptionWhenMinIsLessThanZero()
    {
        var random = Should.Throw<AggregateException>(() =>
        {
            RandomFloat.Next(-1, 1, 1);
        });

        random.ShouldNotBeNull();
        random.InnerExceptions.Count.ShouldBe(1);

        var exception = random.InnerExceptions.First() as ArgumentException;
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType(typeof(ArgumentException));
        exception.Message.Contains("greater than or equal to 0").ShouldBeTrue();
        exception.ParamName.ShouldBe("min");
    }

    [Fact]
    public void ThrowsExceptionWhenMaxIsGreaterThanMaxValue()
    {
        var random = Should.Throw<AggregateException>(() =>
        {
            RandomFloat.Next(1, 999999, 1);
        });

        random.ShouldNotBeNull();
        random.InnerExceptions.Count.ShouldBe(1);

        var exception = random.InnerExceptions.First() as ArgumentException;
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType(typeof(ArgumentException));
        exception.Message.Contains("less than or equal to").ShouldBeTrue();
        exception.ParamName.ShouldBe("max");
    }

    [Fact]
    public void ThrowsExceptionWhenMinIsGreaterThanMax()
    {
        var random = Should.Throw<AggregateException>(() =>
        {
            RandomFloat.Next(2, 1, 1);
        });

        random.ShouldNotBeNull();
        random.InnerExceptions.Count.ShouldBe(1);

        var exception = random.InnerExceptions.First() as ArgumentException;
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType(typeof(ArgumentException));
        exception.Message.Contains("cannot be larger than").ShouldBeTrue();
        exception.ParamName.ShouldBe("min");
    }

    [Fact]
    public void ThrowsExceptionWhenPrecisionIsGreaterThanMaxPrecision()
    {
        var random = Should.Throw<AggregateException>(() =>
        {
            RandomFloat.Next(0, 1, 20);
        });

        random.ShouldNotBeNull();
        random.InnerExceptions.Count.ShouldBe(1);

        var exception = random.InnerExceptions.First() as ArgumentException;
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType(typeof(ArgumentException));
        exception.Message.Contains("must be between").ShouldBeTrue();
        exception.ParamName.ShouldBe("precision");
    }

    [Fact]
    public void ThrowsExceptionWhenPrecisionIsLessThanOne()
    {
        var random = Should.Throw<AggregateException>(() =>
        {
            RandomFloat.Next(0, 1, 0);
        });

        random.ShouldNotBeNull();
        random.InnerExceptions.Count.ShouldBe(1);

        var exception = random.InnerExceptions.First() as ArgumentException;
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType(typeof(ArgumentException));
        exception.Message.Contains("must be between").ShouldBeTrue();
        exception.ParamName.ShouldBe("precision");
    }

    [Fact]
    public void NextTest()
    {
        var random = RandomFloat.Next();

        random.ShouldBeGreaterThan(0);
        random.ShouldBeLessThan(RandomFloat.MaxValue + 1);
        random.ToString().Split('.')[1].Length.ShouldBeLessThanOrEqualTo(RandomFloat.MaxPrecision);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void NextWithPrecisionTest(int precision)
    {
        var random = RandomFloat.Next(precision);

        while (!random.ToString().Contains('.'))
        {
            random = RandomFloat.Next(precision);
        }

        random.ShouldBeGreaterThan(0);
        random.ShouldBeLessThan(RandomFloat.MaxValue + 1);
        var decimals = random.ToString().Split('.');
        decimals.Count().ShouldBe(2);
        decimals[1].Length.ShouldBeGreaterThan(0);
        decimals[1].Length.ShouldBeLessThanOrEqualTo(precision);
    }

    [Fact]
    public void NextWithPrecisionAndMaxTest()
    {
        var precision = 5;
        var max = 9999;

        var random = RandomFloat.Next(max, precision);

        random.ShouldBeGreaterThan(0);
        random.ShouldBeLessThan(max + 1);

        var decimals = random.ToString().Split('.');
        decimals.Count().ShouldBe(2);
        decimals[1].Length.ShouldBeGreaterThan(0);
        decimals[1].Length.ShouldBeLessThanOrEqualTo(precision);
    }

    [Fact]
    public void NextWithPrecisionAndMaxAndMinTest()
    {
        var precision = 5;
        var max = 60;
        var min = 50;

        var random = RandomFloat.Next(min, max, precision);

        random.ShouldBeGreaterThan(min);
        random.ShouldBeLessThan(max + 1);

        var decimals = random.ToString().Split('.');
        decimals.Count().ShouldBe(2);
        decimals[1].Length.ShouldBeGreaterThan(0);
        decimals[1].Length.ShouldBeLessThanOrEqualTo(precision);
    }
}



