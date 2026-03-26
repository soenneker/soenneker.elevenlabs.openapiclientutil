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
    ValueTask<ElevenLabsOpenApiClient> Get(CancellationToken cancellationToken = default);
}
