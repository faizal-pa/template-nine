using System.Diagnostics.CodeAnalysis;
using Asp.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template9.Common.WebApi.OpenApi.Configuration;
using Template9.Common.WebApi.OpenApi.Filters;

namespace Template9.Common.WebApi.OpenApi;

[ExcludeFromCodeCoverage]
public static class CompositionExtensions
{
    /// <summary>
    /// Configures the OpenApi services for the application.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureStandardSwaggerGen(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OpenApiOptions>(configuration.GetSection(OpenApiOptions.SectionName));
        services.ConfigureOptions<OpenApiOptionsConfigurator>();

        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        }).AddMvc()
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        services.AddSwaggerGen(options =>
        {
            options.SchemaFilter<SwaggerExcludeFilter>();
            options.DocumentFilter<SwaggerExcludeFilter>();
            options.OperationFilter<ProblemDetailsFilter>();
        });

        services.ConfigureOptions<ApiVersionsConfigurator>();
        services.ConfigureOptions<XmlDocsConfigurator>();
        services.ConfigureOptions<SwaggerUIOptionsConfigurator>();
        services.ConfigureOptions<RouteTemplateConfigurator>();

        return services;
    }

    /// <summary>
    /// Configures the OpenApi services for the application.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="useSwaggerUI"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseStandardSwaggerUi(this IApplicationBuilder app, bool useSwaggerUI = true)
    {
        app.UseSwagger();
        if (useSwaggerUI) app.UseSwaggerUI();

        return app;
    }
}
