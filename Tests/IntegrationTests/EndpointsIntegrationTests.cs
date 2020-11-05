using System;
using System.Runtime.ExceptionServices;
using Xunit;
using System.Text;
using API.Controllers;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace API.Tests.IntegrationTests
{
    public class EndpointsIntegrationTests
        : IClassFixture<WebApplicationFactory<API.Startup>>
    {
        private readonly WebApplicationFactory<API.Startup> _factory;
        public EndpointsIntegrationTests(WebApplicationFactory<API.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("api/Home")]
        [InlineData("api/UserDetails")]
        public async Task Get_EndpointReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); 
            Assert.Equal("text/plain; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
        
    }
}