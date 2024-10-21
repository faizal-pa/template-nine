using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Template9.Common.Abstractions.DataAnnotations;

/// <summary>
/// Validates that the value is a valid <see cref="DateOnly"/> and is greater than DateOnly.MinValue.
/// </summary>
[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class ValidDateOnlyAttribute : ValidationAttribute
{
    public ValidDateOnlyAttribute()
    {
        ErrorMessage = "The {0} field is must be a valid date.";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (validationContext is null)
        {
            throw new ArgumentNullException(nameof(validationContext));
        }

        if (value is not null && value is DateOnly dateOnlyValue)
        {
            if (dateOnlyValue != DateOnly.MinValue)
            {
                return ValidationResult.Success;
            }
        }

        var memberNames = (!string.IsNullOrWhiteSpace(validationContext.MemberName))
            ? new List<string> { validationContext.MemberName }
            : [];

        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName), memberNames);
    }
}
