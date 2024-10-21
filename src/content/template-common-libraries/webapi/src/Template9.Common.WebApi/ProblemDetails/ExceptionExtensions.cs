using Template9.Common.Exceptions;

namespace Template9.Common.WebApi.ProblemDetails;

public static class ExceptionExtensions
{
    /// <summary>
    /// Converts a <see cref="Template9Exception"/> to a <see cref="Microsoft.AspNetCore.Mvc.ProblemDetails"/>
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static Microsoft.AspNetCore.Mvc.ProblemDetails ToProblemDetails(this Template9Exception exception)
    {
        var pd = new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Detail = exception.Message,
            Instance = exception.Instance,
            Status = exception.StatusCode,
            Title = exception.Title,
            Type = exception.Type
        };

        foreach (var kvp in exception.Extensions)
        {
            pd.Extensions.Add(kvp.Key, kvp.Value);
        }

        return pd;
    }
}
