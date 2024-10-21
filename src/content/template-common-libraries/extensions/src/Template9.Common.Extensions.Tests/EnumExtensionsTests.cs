namespace Template9.Common.Extensions.Tests;

public class EnumExtensionsTests
{
    [Theory]
    [InlineData("Alfa", NatoPhoneticAlphabet.Alfa)]
    [InlineData("Bravo", NatoPhoneticAlphabet.Bravo)]
    [InlineData("Charlie", NatoPhoneticAlphabet.Charlie)]
    [InlineData("Delta", NatoPhoneticAlphabet.Delta)]
    [InlineData("Echo", NatoPhoneticAlphabet.Echo)]
    [InlineData("Foxtrot", NatoPhoneticAlphabet.Foxtrot)]
    [InlineData("Golf", NatoPhoneticAlphabet.Golf)]
    public void ShouldParseStringToEnum(string value, NatoPhoneticAlphabet expected)
    {
        var actual = value.ToEnum<NatoPhoneticAlphabet>();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void ShouldParseStringToEnumCaseInsensitive()
    {
        var expected = NatoPhoneticAlphabet.Alfa;

        var values = new List<string>
        {
            "Alfa",
            "aLFA",
            "ALFA",
            "alfa"
        };

        foreach (var value in values)
        {
            var actual = value.ToEnum<NatoPhoneticAlphabet>();
            actual.ShouldBe(expected);
        }
    }

    [Fact]
    public void ShouldThrowExceptionWhenUnableToParse()
    {
        Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = "Hotel".ToEnum<NatoPhoneticAlphabet>();
        });
    }

    [Fact]
    public void ShouldReturnDefaultWhenUnableToParse()
    {
        var expected = NatoPhoneticAlphabet.Echo;
        var actual = "Hotel".ToEnum(expected);

        actual.ShouldBe(expected);
    }

    [Fact]
    public void ShouldNotReturnDefaultWhenAbleToParse()
    {
        var expected = NatoPhoneticAlphabet.Echo;
        var actual = "Foxtrot".ToEnum(expected);

        actual.ShouldBe(NatoPhoneticAlphabet.Foxtrot);
    }
}

public enum NatoPhoneticAlphabet
{
    Alfa,
    Bravo,
    Charlie,
    Delta,
    Echo,
    Foxtrot,
    Golf
}
