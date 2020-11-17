using System;
using System.Runtime.ExceptionServices;
using Xunit;
using System.Text;
using Api.Controllers;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Api.Tests.IntegrationTests
{
    public class StatusIntegrationTests
        : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly WebApplicationFactory<Api.Startup> _factory;
        public StatusIntegrationTests(WebApplicationFactory<Api.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("api/Home")]
        // [InlineData("api/Employee")]
        // [InlineData("api/Employee/1")]
        // [InlineData("api/Employee/2")]
        // [InlineData("api/Employee/3")]
        // [InlineData("api/Employee/4")]
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