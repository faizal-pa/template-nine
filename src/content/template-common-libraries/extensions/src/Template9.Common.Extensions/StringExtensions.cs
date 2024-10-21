using System.Text;

namespace Template9.Common.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Returns a boolean value indicating whether a string contains any of the specified characters.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="chars"></param>
    /// <returns></returns>
    public static bool Contains(this string s, params char[] chars)
    {
        if (string.IsNullOrEmpty(s)) return false;
        return s.Any(c => chars.Contains(c));
    }

    /// <summary>
    /// Returns a boolean value indicating whether a string contains any of the specified strings.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool Contains(this string value, params string[] values)
    {
        foreach (var x in values)
        {
            if (value.Contains(x, StringComparison.CurrentCultureIgnoreCase)) return true;
        }

        return false;
    }

    /// <summary>
    /// Returns a boolean value indicating whether the string ends with any of the specified strings.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool EndsWith(this string value, params string[] values)
    {
        foreach (var x in values)
        {
            if (value.EndsWith(x, StringComparison.CurrentCultureIgnoreCase)) return true;
        }

        return false;
    }

    /// <summary>
    /// Returns a string that contains the result of Base64 decoding the specified string.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string FromBase64(this string value)
    {
        try
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }
        catch (Exception e)
        {
            throw new ArgumentException("The string being decoded does not appear to be a valid base64 string value.", e);
        }
    }

    /// <summary>
    /// Returns a boolean value indicating whether the string contains any whitespace characters.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool HasWhiteSpace(this string s)
    {
        if (string.IsNullOrEmpty(s)) return false;
        return s.Any(c => char.IsWhiteSpace(c));
    }

    /// <summary>
    /// Returns a boolean value indicating whether the string starts with any of the specified strings.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool StartsWith(this string value, params string[] values)
    {
        foreach (var x in values)
        {
            if (value.StartsWith(x, StringComparison.CurrentCultureIgnoreCase)) return true;
        }

        return false;
    }

    /// <summary>
    /// Returns a Base64 encoded representation of the specified string.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToBase64(this string value)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
    }

    /// <summary>
    /// Converts the specified string to a nullable decimal. Returns null if the conversion fails.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static decimal? ToNullableDecimal(this string? s)
    {
        return decimal.TryParse(s, out var result)
            ? result
            : null;
    }

    /// <summary>
    /// Combines multiple strings into a url path by separating strings with the forward slash(/) and removing .
    /// </summary>
    /// <param name="path"></param>
    /// <param name="sections"></param>
    /// <remarks>
    ///     Each parameter is trimmed of any leading and trailing whitespace.
    ///     The base string has any trailing forward slashes removed.
    ///     Each subsequent parameter has any leading and trailing forward slashes removed.
    ///     The remaining strings are joined using the forward slash as the separator.
    ///     <para>Does not do any encoding on the string.</para>
    /// </remarks>
    public static string UriCombine(this string path, params string[] sections)
    {
        if (sections.IsNullOrEmpty()) return path;

        var builder = new List<string> { path.Trim().TrimEnd('/') };
        sections.ToList().ForEach(x => builder.Add(x.Trim().TrimEnd('/').TrimStart('/')));

        return string.Join('/', builder);
    }
}
