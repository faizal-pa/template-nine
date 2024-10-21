using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using Template9.Common.Exceptions;

namespace Template9.Common.WebApi.ProblemDetails;

public class ProblemDetailsOptionsConfigurator : IConfigureOptions<Hellang.Middleware.ProblemDetails.ProblemDetailsOptions>
{
    private readonly IWebHostEnvironment _environment;

    public ProblemDetailsOptionsConfigurator(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public void Configure(Hellang.Middleware.ProblemDetails.ProblemDetailsOptions options)
    {
        // Only include exception details in a development environment. There's really no need
        // to set this as it's the default behavior. It's just included here for completeness :)
        options.IncludeExceptionDetails = (ctx, ex) => _environment.IsDevelopment();

        // Add custom mapping for exceptions that derive from ProblemDetailsException
        options.Map<Template9Exception>(ex => ex.ToProblemDetails());

        // Maps the trace id property on the problem detail to something.
        // options.GetTraceId = (ctx) => Guid.NewGuid().ToString();

        // This will map NotImplementedException to the 501 Not Implemented status code.
        options.MapToStatusCode<NotImplementedException>(StatusCodes.Status501NotImplemented);

        // This will map HttpRequestException to the 503 Service Unavailable status code.
        options.MapToStatusCode<HttpRequestException>(StatusCodes.Status503ServiceUnavailable);

        // Because exceptions are handled polymorphically, this will act as a "catch all" mapping, which is why it's added last.
        // If an exception other than NotImplementedException and HttpRequestException is thrown, this will handle it.
        options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
    }
}
