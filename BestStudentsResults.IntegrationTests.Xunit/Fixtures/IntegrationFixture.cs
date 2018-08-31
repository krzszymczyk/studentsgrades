using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration.Json;

namespace BestStudentsResults.IntegrationTests.Xunit.Fixtures
{
    public class IntegrationFixture:IDisposable
    {
        private TestServer server;
        public HttpClient Client { get; }

        public IntegrationFixture()
        {
            var jsonConfigurationSource = new JsonConfigurationSource();
            jsonConfigurationSource.Path = "appsettings.json";

            server = new TestServer(new WebHostBuilder().UseStartup<Startup>().ConfigureAppConfiguration(b=>b.Add(jsonConfigurationSource)));
            Client = server.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            server.Dispose();

        }
    }
}
