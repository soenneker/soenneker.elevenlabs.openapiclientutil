using Soenneker.ElevenLabs.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.ElevenLabs.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class ElevenLabsOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IElevenLabsOpenApiClientUtil _openapiclientutil;

    public ElevenLabsOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IElevenLabsOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
