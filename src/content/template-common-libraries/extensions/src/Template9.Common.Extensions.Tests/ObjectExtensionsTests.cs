namespace Template9.Common.Extensions.Tests;

public class ObjectExtensionsTests
{
    [Fact]
    public void GetTypeNameTests()
    {
        var actual = new Dictionary<int, IEnumerable<long>>().GetTypeName();
        actual.ShouldBe("DictionaryInt32IEnumerableInt64");

        actual = new Dictionary<int, List<string>>().GetTypeName();
        actual.ShouldBe("DictionaryInt32ListString");

        actual = new Dictionary<string, object>().GetTypeName();
        actual.ShouldBe("DictionaryStringObject");

        actual = new List<int>().GetTypeName();
        actual.ShouldBe("ListInt32");

        actual = new object().GetTypeName();
        actual.ShouldBe("Object");
    }
}
