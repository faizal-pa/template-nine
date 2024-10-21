using System.Diagnostics.CodeAnalysis;

namespace Template9.Common.Exceptions;

[ExcludeFromCodeCoverage]
public abstract class Template9Exception : Exception
{
    /// <summary>
    /// A URI reference [RFC3986] that identifies the problem type. The specification encourages that,
    /// when dereferenced, it provide human-readable documentation for the problem type (e.g., using
    /// HTML [W3C.REC-html5-20141028]). When this member is not present, its value is assumed to be "about:blank".
    /// </summary>
    public string Type { get; set; } = "about:blank";

    /// <summary>
    /// The HTTP status code
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// A short, human-readable summary of the problem type. It SHOULD NOT change from occurrence
    /// to occurrence of the problem, except for purposes of localization.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// A URI reference that identifies the specific occurrence of the problem. It may or may not yield
    /// further information if dereferenced.
    /// </summary>
    public string Instance { get; set; } = null!;

    /// <summary>
    /// Additional members that extend the problem details object.
    /// </summary>
    public Dictionary<string, string> Extensions { get; } = [];

    public Template9Exception() : base()
    { }

    public Template9Exception(string message) : this(message, 500, "Internal Server Error", "", "", null)
    { }

    public Template9Exception(string message, Exception innerException) : this(message, 500, "Internal Server Error", "", "", innerException)
    { }

    protected Template9Exception(string message, int statusCode, string title, string type, string instance, Exception? innerException = null) : base(message, innerException)
    {
        StatusCode = statusCode;
        Title = title;
        Type = type;
        Instance = instance;
    }
}
