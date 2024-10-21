using System.Diagnostics.CodeAnalysis;

namespace Template9.Common.Abstractions.DataAnnotations;

/// <summary>
/// Specified that the target should not show up in the OpenApi specification produced by Swashbuckle.
/// </summary>
[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Field | AttributeTargets.Property)]
public sealed class SwaggerExcludeAttribute : Attribute { }
