using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.ElevenLabs.HttpClients.Abstract;
using Soenneker.ElevenLabs.OpenApiClientUtil.Abstract;
using Soenneker.ElevenLabs.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.ElevenLabs.OpenApiClientUtil;

///<inheritdoc cref="IElevenLabsOpenApiClientUtil"/>
public sealed class ElevenLabsOpenApiClientUtil : IElevenLabsOpenApiClientUtil
{
    private readonly AsyncSingleton<ElevenLabsOpenApiClient> _client;

    public ElevenLabsOpenApiClientUtil(IElevenLabsOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<ElevenLabsOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("ElevenLabs:ApiKey");
            string authHeaderValueTemplate = configuration["ElevenLabs:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
