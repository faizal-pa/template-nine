using System.Text.Json;

namespace Template9.Common.Extensions;

public static class DeepClone
{
    public static JsonSerializerOptions Options { get; set; } = new JsonSerializerOptions();
}

public static class DeepCloneExtensions
{
    /// <summary>
    /// Returns a deep clone of the object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <remarks>The deep clone is created by serializing the object to JSON, and then deserializing JSON back to a new object.</remarks>
    public static T? DeepClone<T>(this T obj) => obj.DeepClone(Extensions.DeepClone.Options);

    /// <summary>
    /// Returns a deep clone of the object using the provided JsonSerializerOptions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="options"></param>
    /// <remarks>The deep clone is created by serializing the object to JSON, and then deserializing JSON back to a new object.</remarks>
    public static T? DeepClone<T>(this T obj, JsonSerializerOptions options)
    {
        var json = JsonSerializer.Serialize(obj, options);
        var clone = JsonSerializer.Deserialize<T>(json, options);
        return clone;
    }
}
