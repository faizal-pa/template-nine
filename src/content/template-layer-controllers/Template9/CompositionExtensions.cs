using Microsoft.Extensions.DependencyInjection;

namespace Template9;

public static class CompositionExtensions
{
    /// <summary>
    /// Add the controllers to the application and allows the documentation to be generated.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IMvcBuilder AddSampleControllers(this IMvcBuilder builder)
    {
        builder.AddApplicationPart(typeof(CompositionExtensions).Assembly);
        return builder;
    }
}