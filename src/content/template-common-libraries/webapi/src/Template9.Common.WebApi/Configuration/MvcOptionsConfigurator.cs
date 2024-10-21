using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;

namespace Template9.Common.WebApi.Configuration;

/// <summary>
/// Configures the <see cref="MvcOptions"/> for the application.
/// </summary>
[ExcludeFromCodeCoverage]
public class MvcOptionsConfigurator : IPostConfigureOptions<MvcOptions>
{
    private readonly StandardConfigOptions _options;

    public MvcOptionsConfigurator(IOptions<StandardConfigOptions> options)
    {
        _options = options.Value;
    }

    public void PostConfigure(string? name, MvcOptions options)
    {
        if (_options.RemoveStringOutputFormatters)
            options.OutputFormatters.RemoveType<StringOutputFormatter>();

        if (_options.RemoveTextJsonMediaType)
            options.OutputFormatters.OfType<SystemTextJsonOutputFormatter>()
                .FirstOrDefault()?.SupportedMediaTypes.Remove("text/json");

        if (_options.AddResponseType400BadRequest)
            options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));

        if (_options.AddResponseType406NotAcceptable)
            options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));

        if (_options.AddResponseType500InternalServerError)
            options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));

        if (_options.ReturnHttpNotAcceptable)
            options.ReturnHttpNotAcceptable = true;
    }

}
