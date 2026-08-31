[![](https://img.shields.io/nuget/v/soenneker.elevenlabs.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.elevenlabs.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.elevenlabs.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.elevenlabs.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.elevenlabs.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.elevenlabs.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.elevenlabs.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.elevenlabs.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.ElevenLabs.OpenApiClientUtil

Provides lazy, cached access to the generated ElevenLabs API client.

## Installation

```bash
dotnet add package Soenneker.ElevenLabs.OpenApiClientUtil
```

## Configure and register

```json
{
  "ElevenLabs": {
    "ApiKey": "your-api-key"
  }
}
```

```csharp
using Soenneker.ElevenLabs.OpenApiClientUtil.Registrars;

services.AddElevenLabsOpenApiClientUtilAsScoped();
```

## Use the client

```csharp
using Soenneker.ElevenLabs.OpenApiClientUtil.Abstract;

public sealed class VoiceReader(IElevenLabsOpenApiClientUtil clients)
{
    public async Task Read(CancellationToken cancellationToken)
    {
        var client = await clients.Get(cancellationToken);
        var response = await client.V1.Voices.GetAsync(
            cancellationToken: cancellationToken);
    }
}
```

The first call to `Get()` creates the generated client; later calls on the same utility instance return it from the cache. The HTTP provider applies the `xi-api-key` header, so the generated client does not add a second authentication header.

Use `AddElevenLabsOpenApiClientUtilAsSingleton()` when the application should share one generated client. A scoped utility borrows the singleton HTTP provider; disposing the scope releases the utility without destroying the shared transport.
