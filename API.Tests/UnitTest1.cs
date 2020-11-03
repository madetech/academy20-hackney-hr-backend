using System;
using Xunit;

namespace API.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

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