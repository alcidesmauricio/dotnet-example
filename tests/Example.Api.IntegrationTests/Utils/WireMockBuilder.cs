using WireMock.Server;

namespace Example.Api.IntegrationTests.Utils;

public class WireMockBuilder
{
    protected WireMockBuilder()
    {

    }

    private static volatile WireMockServer? _server;
    private static object _syncRoot = new();

    public static WireMockServer Build(int port = 5006)
    {
        if (_server is null)
        {
            lock (_syncRoot)
            {
                _server ??= WireMockServer.Start(port);
            }
        }
        return _server;
    }
}