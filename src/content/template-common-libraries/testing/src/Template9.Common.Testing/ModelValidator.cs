using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Template9.Common.Testing;

[ExcludeFromCodeCoverage]
public static class ModelValidator
{
    /// <summary>
    /// Validate the model using DataAnnotations and IValidatableObject.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="model"></param>
    /// <returns></returns>
    public static IList<ValidationResult> Validate<TModel>(TModel model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));

        var results = new List<ValidationResult>();
        var context = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, context, results, true);

        if (model is IValidatableObject validatableObject)
            results.AddRange(validatableObject.Validate(context));

        return results;
    }
}
