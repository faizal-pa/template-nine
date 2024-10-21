namespace Template9.Common.Extensions.Tests;

public class StringExtensionsTests
{
    [Fact]
    public void Base64Tests()
    {
        var value = "This is a string of text";
        var expected = "VGhpcyBpcyBhIHN0cmluZyBvZiB0ZXh0";

        var encoded = value.ToBase64();
        encoded.ShouldBe(expected);

        var decoded = encoded.FromBase64();
        decoded.ShouldBe(value);
    }

    [Fact]
    public void ContainsCharacterTests()
    {
        var value = "This is the string";
        value.Contains('c').ShouldBeFalse();
        value.Contains('i').ShouldBeTrue();

        value.Contains('c', 'a').ShouldBeFalse();
        value.Contains('i', 's').ShouldBeTrue();

        value.Contains(new char[] { 'c', 'a' }).ShouldBeFalse();
        value.Contains(new char[] { 'i', 's' }).ShouldBeTrue();
    }

    [Fact]
    public void ContainsStringTests()
    {
        var value = "The quick brown fox jumped over the lazy dog";
        value.Contains("pony").ShouldBeFalse();
        value.Contains("fox").ShouldBeTrue();

        value.Contains("fish", "cat", "horse").ShouldBeFalse();
        value.Contains("fox", "dog").ShouldBeTrue();

        value.Contains(new string[] { "fish", "cat", "horse" }).ShouldBeFalse();
        value.Contains(new string[] { "fox", "dog" }).ShouldBeTrue();
    }

    [Fact]
    public void EndsWithTest()
    {
        var value = "The quick brown fox jumped over the lazy dog";

        value.EndsWith("dog").ShouldBeTrue();
        value.EndsWith("fox").ShouldBeFalse();

        value.EndsWith("dog", "cat", "bird").ShouldBeTrue();
        value.EndsWith("mole", "fox", "fish").ShouldBeFalse();

        value.EndsWith(new string[] { "dog", "cat", "bird" }).ShouldBeTrue();
        value.EndsWith(new string[] { "mole", "fox", "fish" }).ShouldBeFalse();
    }

    [Theory]
    [InlineData("This string has white space", true)]
    [InlineData("This.string.does.not", false)]
    public void HasWhiteSpaceTest(string value, bool expected)
    {
        value.HasWhiteSpace().ShouldBe(expected);
    }

    [Fact]
    public void NullableDecimalTests()
    {
        string value = null;
        value.ToNullableDecimal().ShouldBe(null);

        value = "";
        value.ToNullableDecimal().ShouldBe(null);

        value = " ";
        value.ToNullableDecimal().ShouldBe(null);

        value = "Alphabet";
        value.ToNullableDecimal().ShouldBe(null);

        value = "0";
        value.ToNullableDecimal().ShouldBe(0m);

        value = "123.45";
        value.ToNullableDecimal().ShouldBe(123.45m);
    }

    [Fact]
    public void StartsWithTest()
    {
        var value = "The quick brown fox jumped over the lazy dog";

        value.StartsWith("The").ShouldBeTrue();
        value.StartsWith("An").ShouldBeFalse();

        value.StartsWith("That", "The", "For").ShouldBeTrue();
        value.StartsWith("A", "An", "Another").ShouldBeFalse();

        value.StartsWith(new string[] { "That", "The", "For" }).ShouldBeTrue();
        value.StartsWith(new string[] { "A", "An", "Another" }).ShouldBeFalse();
    }

    [Theory]
    [InlineData("part1/part2/part3/part4/part5", "part1", "part2", "part3", "part4", "part5")]
    [InlineData("part1/part2/part3/part4/part5", "part1/", "/part2/", "/part3/", "/part4/", "/part5/")]
    [InlineData("/part1/part2/part3/part4/part5", "/part1/", "/part2/part3/", "/part4/", "/part5/")]
    public void UriCombineTests(string expected, string path, params string[] sections)
    {
        var actual = path.UriCombine(sections);
        actual.ShouldBe(expected);
    }
}
