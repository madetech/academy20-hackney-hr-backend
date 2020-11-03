using System;
using System.Runtime.ExceptionServices;
using Xunit;
using System.Text;
using API.Controllers;
using System.Threading.Tasks;
using System.Net.Http;

// connection refused error when run
namespace tests
{
    public class UnitTests
    {
        [Fact]
        public async Task GetHomeEndPoint()
        {
            // Arrange
            var apiClient = new HttpClient();

            // Act
            var apiResponse = await apiClient.GetAsync($"http://localhost:5001/api/home");

            var stringResponse = await apiResponse.Content.ReadAsStringAsync();
            

            // Assert
            Assert.True(apiResponse.IsSuccessStatusCode);
            // Assert.Equal("Welcome to our home page. Please log in.", stringResponse);


        }
    }
}



