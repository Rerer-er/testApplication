using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestApplication;
using Xunit;

namespace UnitTests
{
    public class KindTest
    {
        private readonly string _headersAuth;
        private readonly HttpClient _client;
        class Parse
        {
            public string token { get; set; }
        }
        public static IEnumerable<object[]> TestKind1()
        {
            yield return new object[]
                {
                   new Kind(){ Name = "testname1", About = "testname1", Foto = "https" },
                };
        }
        public static IEnumerable<object[]> TestKind2()
        {
            yield return new object[]
                {
                   new Kind(){ Name = "testname2", About = "testname2", Foto = "https" },
                };
        }
        public static UserForAuthenticationDto TestUser()
        {
            return new UserForAuthenticationDto() { UserName = "test1", Password = "test1test1"};
        }
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
            _headersAuth =  AddNewUser(TestUser());
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _headersAuth);
        }

        
        public string AddNewUser(UserForAuthenticationDto newUser)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");
            var apiResponse = _client.PostAsync($"/authentication/login", stringContent);
            var a = apiResponse.Result.Content.ReadAsStringAsync();
            var str = a.Result;
            var sr = JsonConvert.DeserializeObject<Parse>(str);
            return sr.token;
            //var apiResponse = await _client.GetAsync("/authentication");
            //Assert.Equal(StatusCodes.Status200OK, (int)apiResponse.StatusCode);
        }
        [Fact]
        public async Task GetAllKindsTest()
        {
            var apiResponse = await _client.GetAsync("/kinds");
            Assert.Equal(StatusCodes.Status200OK, (int)apiResponse.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetKindTest(int id)
        {
            var apiResponse = await _client.GetAsync($"/kinds/{id}");
            Assert.Equal(StatusCodes.Status200OK, (int)apiResponse.StatusCode);
        }
        [Theory]
        [MemberData(nameof(TestKind1))]
        [MemberData(nameof(TestKind2))]
        public async Task PostKindTest(Kind kind)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(kind), Encoding.UTF8, "application/json");
            var apiResponse = await _client.PostAsync($"/kinds", stringContent);
            Assert.Equal(StatusCodes.Status200OK, (int)apiResponse.StatusCode);
        }
        [Theory]
        [MemberData(nameof(TestKind1))]
        [MemberData(nameof(TestKind2))]
        public async Task PutKindTest(Kind kind)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(kind), Encoding.UTF8, "application/json");
            var apiResponse = await _client.PostAsync($"/kinds", stringContent);

            var rootobject = JsonConvert.DeserializeObject<Kind>(apiResponse.Content.ReadAsStringAsync().Result);
            rootobject.Name = "puttest";
            stringContent = new StringContent(JsonConvert.SerializeObject(rootobject), Encoding.UTF8, "application/json");
            
            apiResponse = await _client.PutAsync($"/kinds/{rootobject.KindId}", stringContent);
            Assert.Equal(StatusCodes.Status204NoContent, (int)apiResponse.StatusCode);

            apiResponse = await _client.PostAsync($"/kinds", stringContent);
            var finalKind = JsonConvert.DeserializeObject<Kind>(apiResponse.Content.ReadAsStringAsync().Result);
            Assert.NotEqual(finalKind, kind);
        }
        [Theory]
        [MemberData(nameof(TestKind1))]
        [MemberData(nameof(TestKind2))]
        public async Task DeleteKindTest(Kind kind)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(kind), Encoding.UTF8, "application/json");
            var apiResponse = await _client.PostAsync($"/kinds", stringContent);

            var newKind = JsonConvert.DeserializeObject<Kind>(apiResponse.Content.ReadAsStringAsync().Result);
            
            apiResponse = await _client.DeleteAsync($"/kinds/{newKind.KindId}");
            Assert.Equal(StatusCodes.Status204NoContent, (int)apiResponse.StatusCode);

            apiResponse = await _client.GetAsync($"/kinds/{newKind.KindId}");
            Assert.Equal(StatusCodes.Status404NotFound, (int)apiResponse.StatusCode);
        }
    }
}
