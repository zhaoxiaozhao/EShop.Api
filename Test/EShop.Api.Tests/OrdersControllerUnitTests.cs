using EShop.Api.Entities;
using EShop.Api.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace EShop.Api.Tests
{
    public class OrdersControllerUnitTests
    {
        private readonly HttpClient _client;

        public OrdersControllerUnitTests()
        {
            var webAppFactory = new CustomWebApplicationFactory<Program>();
            _client = webAppFactory.CreateDefaultClient();
        }

        [Fact]
        public async Task HelloWorld_SuccessedAsync()
        {
            var response = await _client.GetAsync("/api/get");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal("Hello World!", responseString);
        }

        [Fact]
        public async Task PostOrder_CreatedAysnc()
        {
            //arrange
            var Order = new Order()
            {
                BillingZipCode = "2",
                BuyerName ="张三",
                OrderAmount = 10,
                PuchaseOrderNumber = "100001"
            };

            //act
            var response = await _client.PostAsJsonAsync("/api/postorder", Order);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("True", responseString);
        }

        [Fact]
        public async Task PostOrder_NoContentAysnc()
        {
            //arrange
            var Order = new Order()
            {
                BillingZipCode = "2",
                BuyerName = "李四",
                OrderAmount = 10,
                PuchaseOrderNumber = "100002"
            };

            //act
            var response = await _client.PostAsJsonAsync("/api/postorder", Order);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task PostOrder_BadRequestAysnc()
        {
            //arrange
            var Order = new Order()
            {
                BuyerName = "张三",
                OrderAmount = 10,
                PuchaseOrderNumber = "100003"
            };

            //act
            var response = await _client.PostAsJsonAsync("/api/postorder", Order);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetOrders_SuccessedAsync()
        {
            //act
            var response = await _client.GetAsync("/api/getorders?code=2");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Order>>(responseString);

            // Assert
            Assert.Equal("李四", result.FirstOrDefault()?.BuyerName);
        }
    }
}