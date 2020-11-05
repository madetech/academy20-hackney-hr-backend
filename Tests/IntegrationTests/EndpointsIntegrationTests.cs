using System;
using System.Runtime.ExceptionServices;
using Xunit;
using System.Text;
using API.Controllers;
using System.Threading.Tasks;
using System.Net;
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
        [InlineData("api/Employee")]
        public async Task Get_EndpointReturnSuccess(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        }
        
    }
}