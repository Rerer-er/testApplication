using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestApplication;
using Xunit;

namespace UnitTests
{
    public class KindTest
    {
        private readonly HttpClient _client;
        public KindTest()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var webBuilder = new WebHostBuilder()
            .UseConfiguration(builder.Build())
            .UseStartup<Startup>();

            var server = new TestServer(webBuilder);

            _client = server.CreateClient();

        }
        [Fact]
        public async Task GetAllKindsTest()
        {
            var apiResponse = await _client.GetAsync("/kinds");
            Assert.Equal(StatusCodes.Status200OK, (int)apiResponse.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public async Task GetKindTest(int id)
        {
            var apiResponse = await _client.GetAsync($"/kinds/{id}");
            Assert.Equal(StatusCodes.Status200OK, (int)apiResponse.StatusCode);
        }
    }
}
