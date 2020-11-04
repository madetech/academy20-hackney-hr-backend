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

// public class WeatherForecastControllerTests: IClassFixture<WebApplicationFactory<Api.Startup>>
// {
//     readonly HttpClient _client { get; }

//     public WeatherForecastControllerTests(WebApplicationFactory<Api.Startup> fixture)
//     {
//         _client = fixture.CreateClient();
//     }

//     [Fact]
//     public async Task Get_Should_Retrieve_Forecast()
//     {
//         var response = await _client.GetAsync("/weatherforecast");
//         response.StatusCode.Should().Be(HttpStatusCode.OK);
 
//         var forecast = JsonConvert.DeserializeObject<WeatherForecast[]>(await response.Content.ReadAsStringAsync());
//         forecast.Should().HaveCount(5);
//     }
// }
