using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Template9.Common.Abstractions.DataAnnotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Template9.Common.WebApi.OpenApi.Filters;

/// <summary>
/// Removes items from the OpenApi specification that are decorated with the <see cref="SwaggerExcludeAttribute"/> attribute 
/// </summary>
[ExcludeFromCodeCoverage]
public class SwaggerExcludeFilter : ISchemaFilter, IDocumentFilter
{
    private static readonly HashSet<string> _excludeKeys = new();

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type.GetCustomAttribute<SwaggerExcludeAttribute>() != null)
        {
            if (!string.IsNullOrWhiteSpace(context.Type.FullName))
                _excludeKeys.Add(context.Type.FullName);
            return;
        }

        RemoveExcludedProperties(schema, context);
        RemoveExcludedEnums(schema, context);
    }

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        foreach (var key in swaggerDoc.Components.Schemas.Keys)
        {
            if (_excludeKeys.Any(x => x.EndsWith(key)))
            {
                swaggerDoc.Components.Schemas.Remove(key);
            }
        }
    }

    private static void RemoveExcludedProperties(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Properties != null)
        {
            var excludedProperties = context.Type.GetProperties().Where(t => t.GetCustomAttribute<SwaggerExcludeAttribute>() != null);

            foreach (var excludedProperty in excludedProperties)
            {
                var propertyToRemove = schema.Properties.Keys.SingleOrDefault(x => string.Equals(x, excludedProperty.Name, StringComparison.OrdinalIgnoreCase));

                if (propertyToRemove != null)
                {
                    schema.Properties.Remove(propertyToRemove);
                }
            }
        }
    }

    private static void RemoveExcludedEnums(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type.IsEnum || (Nullable.GetUnderlyingType(context.Type)?.IsEnum ?? false))
        {
            var type = (context.Type.IsEnum)
                ? context.Type
                : Nullable.GetUnderlyingType(context.Type);

            if (type == null) return;

            var enums = new List<IOpenApiAny>();

            foreach (var name in Enum.GetNames(type))
            {
                var value = type.GetMember(name)[0];
                if (!value.GetCustomAttributes<SwaggerExcludeAttribute>().Any())
                {
                    enums.Add(new OpenApiString(name));
                }
            }

            schema.Enum = enums;
        }
    }
}
