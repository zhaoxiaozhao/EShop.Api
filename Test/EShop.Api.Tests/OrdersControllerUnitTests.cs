using EShop.Api.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using System.Net.Http;

namespace EShop.Api.Tests
{
    public class OrdersControllerUnitTests
    {
        //private readonly Mock<IOrderServices> _OrderManageMock = new();
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public OrdersControllerUnitTests()
        {
            var webBuilder = new WebHostBuilder();
            webBuilder.UseStartup<Startup>();
            _server = new TestServer(webBuilder);
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task PostOrder_SuccessedAsync()
        {
            var response = await _client.GetAsync("/api/get");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal("Hello World!", responseString);
        }
    }
}