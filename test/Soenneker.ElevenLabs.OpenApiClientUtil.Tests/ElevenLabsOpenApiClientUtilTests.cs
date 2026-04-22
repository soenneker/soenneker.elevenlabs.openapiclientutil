using Soenneker.ElevenLabs.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.ElevenLabs.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class ElevenLabsOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IElevenLabsOpenApiClientUtil _openapiclientutil;

    public ElevenLabsOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IElevenLabsOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
