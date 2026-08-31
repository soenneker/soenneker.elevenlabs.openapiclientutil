using Soenneker.ElevenLabs.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.ElevenLabs.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides lazy access to a cached ElevenLabs API client.
/// </summary>
public interface IElevenLabsOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached ElevenLabs API client, creating it on first use.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The generated ElevenLabs API client.</returns>
    ValueTask<ElevenLabsOpenApiClient> Get(CancellationToken cancellationToken = default);
}
