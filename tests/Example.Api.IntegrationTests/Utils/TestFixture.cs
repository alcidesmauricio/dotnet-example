using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using WireMock.Server;

namespace Example.Api.IntegrationTests.Utils;

class TestFixture : WebApplicationFactory<Program>
{
    public WireMockServer? MockServer { get; private set; }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddJsonFile("appsettings.json");
        }).UseEnvironment("Development");

        MockServer = WireMockBuilder.Build();

        return base.CreateHost(builder);
    }
}