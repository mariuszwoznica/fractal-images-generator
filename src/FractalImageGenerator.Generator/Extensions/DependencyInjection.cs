using Microsoft.Extensions.DependencyInjection;

namespace FractalImageGenerator.Generator.Extensions;

public static class DependencyInjection
{
    /// <summary>
    /// Registers generator and factory types.
    /// </summary>
    /// <param name="collection">Service collection</param>
    /// <returns>Service collection</returns>
    public static IServiceCollection AddGenerator(this IServiceCollection collection)
    {
        collection.AddTransient<Generator>();
        collection.AddTransient<FractalFactory>();
        
        return collection;
    }
}
