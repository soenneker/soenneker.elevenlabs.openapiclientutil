using Soenneker.ElevenLabs.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.ElevenLabs.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IElevenLabsOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<ElevenLabsOpenApiClient> Get(CancellationToken cancellationToken = default);
}
