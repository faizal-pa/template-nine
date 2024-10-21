namespace Template9.Common.Abstractions;

/// <summary>
/// Contains data that should persist across an asynchronous flow.
/// </summary>
public static class CurrentContext
{
    private static readonly AsyncLocal<Guid> _correlationId = new();

    public static Guid CorrelationId
    {
        get => _correlationId.Value;
        set => _correlationId.Value = value;
    }
}
