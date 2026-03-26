using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.ElevenLabs.HttpClients.Registrars;
using Soenneker.ElevenLabs.OpenApiClientUtil.Abstract;

namespace Soenneker.ElevenLabs.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class ElevenLabsOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ElevenLabsOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddElevenLabsOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddElevenLabsOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IElevenLabsOpenApiClientUtil, ElevenLabsOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ElevenLabsOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddElevenLabsOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddElevenLabsOpenApiHttpClientAsSingleton()
                .TryAddScoped<IElevenLabsOpenApiClientUtil, ElevenLabsOpenApiClientUtil>();

        return services;
    }
}
