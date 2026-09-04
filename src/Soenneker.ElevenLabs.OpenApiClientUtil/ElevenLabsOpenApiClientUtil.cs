using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.ElevenLabs.HttpClients.Abstract;
using Soenneker.ElevenLabs.OpenApiClientUtil.Abstract;
using Soenneker.ElevenLabs.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.ElevenLabs.OpenApiClientUtil;

/// <inheritdoc cref="IElevenLabsOpenApiClientUtil" />
public sealed class ElevenLabsOpenApiClientUtil : IElevenLabsOpenApiClientUtil
{
    private readonly AsyncSingleton<ElevenLabsOpenApiClient> _client;

    public ElevenLabsOpenApiClientUtil(IElevenLabsOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<ElevenLabsOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new ElevenLabsOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<ElevenLabsOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
