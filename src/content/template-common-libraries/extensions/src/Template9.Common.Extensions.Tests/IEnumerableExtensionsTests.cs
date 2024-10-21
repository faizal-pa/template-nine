namespace Template9.Common.Extensions.Tests;

public class IEnumerableExtensionsTests
{
    [Theory]
    [InlineData(null)]
    public void IsNotNullAndHasItemsTests(List<string> sequence)
    {
        sequence.IsNotNullAndHasItems().ShouldBeFalse();

        sequence = [];
        sequence.IsNotNullAndHasItems().ShouldBeFalse();

        sequence.Add(Guid.NewGuid().ToString());
        sequence.IsNotNullAndHasItems().ShouldBeTrue();
    }

    [Theory]
    [InlineData(null)]
    public void IsNullOrEmptyTests(List<string> sequence)
    {
        sequence.IsNullOrEmpty().ShouldBeTrue();

        sequence = [];
        sequence.IsNullOrEmpty().ShouldBeTrue();

        sequence.Add(Guid.NewGuid().ToString());
        sequence.IsNullOrEmpty().ShouldBeFalse();
    }

    [Theory]
    [InlineData("Alfa", true)]
    [InlineData("Bravo", true)]
    [InlineData("Charlie", true)]
    [InlineData("Delta", false)]
    public void InTests(string value, bool expected)
    {
        var actual = value.In("Alfa", "Bravo", "Charlie");
        actual.ShouldBe(expected);
    }

    [Fact]
    public void ShuffleTest()
    {
        var set = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.ToList();

        var actual = set.Shuffle().ToList();

        actual.ShouldNotBeNull();
        actual.Count.ShouldBe(set.Count);
        actual.All(x => set.Contains(x)).ShouldBeTrue();
        set.All(x => actual.Contains(x)).ShouldBeTrue();

        var shuffled = false;
        for (var i = 0; i < set.Count; i++)
        {
            if (actual[i] == set[i]) continue;
            shuffled = true;
            break;
        }

        shuffled.ShouldBeTrue();
    }
}

internal class Node
{
    public int Value { get; set; }

    public IEnumerable<Node> Children { get; set; } = null!;
}
