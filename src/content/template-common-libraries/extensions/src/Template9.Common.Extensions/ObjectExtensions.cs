namespace Template9.Common.Extensions;

public static class ObjectExtensions
{
    /// <summary>
    /// Returns a string representing the type name of the object, or the concatenated names of generic type arguments if applicable.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string GetTypeName(this object obj)
    {
        return obj is Type type
            ? GetTypeName(type)
            : GetTypeName(obj.GetType());
    }

    private static string GetTypeName(Type type)
    {
        if (!type.IsGenericType)
            return type.Name;

        var genericArguments = string.Join("", type.GetGenericArguments().Select(GetTypeName));
        var genericTypeName = type.Name.Substring(0, type.Name.IndexOf('`'));
        return $"{genericTypeName}{genericArguments}";
    }
}
