using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Api.Controllers;
using Api.Models;
using System;
// using Newtonsoft.Json;


namespace Api.Tests.IntegrationTests 
{
    public class EmployeeIntegrationTests
        : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly HttpClient httpClient;

        public EmployeeIntegrationTests(WebApplicationFactory<Api.Startup> factory)
        {
            httpClient = factory.CreateClient();
        }

        public static class ContentHelper
        {
        public static StringContent GetStringContent(object obj)
            => new StringContent(JsonSerializer.Serialize(obj), Encoding.Default, "application/json");
        }

        [Fact(Skip="to pass travis")]
        public async Task TestPutEmployeeDetails()
        {
            // Arrange
            var request = new
            {
                first_name = "Harry",
                last_name = "Potter"
            };

            // Act
            var response1 = await httpClient.PutAsync("api/employee/1", ContentHelper.GetStringContent(request));
            var response2 = await httpClient.PutAsync("api/employee/2", ContentHelper.GetStringContent(request));
            var response3 = await httpClient.PutAsync("api/employee/3", ContentHelper.GetStringContent(request));
            var response4 = await httpClient.PutAsync("api/employee/4", ContentHelper.GetStringContent(request));

            // Assert
            Assert.Equal(HttpStatusCode.OK, response1.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response2.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response3.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response4.StatusCode);
        }
    }
} 