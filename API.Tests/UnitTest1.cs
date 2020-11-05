using System;
using System.Runtime.ExceptionServices;
using Xunit;
using System.Text;
using API.Controllers;
using System.Threading.Tasks;
using System.Net.Http;

// using NUnit.Framework;
// using RestSharp;
// using System.Net;

// connection refused error when run
// #################### xUnit
namespace API.Tests
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

            Assert.True(apiResponse.IsSuccessStatusCode);
            
            var stringResponse = await apiResponse.Content.ReadAsStringAsync();
            
            // Assert
            
            Assert.Equal("Welcome to our home page. Please log in.", stringResponse);


        }
    }
}

// ################# NUnit
// namespace API.Tests
// {
//     [TestFixture]
//     public class UnitTests
//     {
//         [Test]
//         public void HomepageStatusCodeTest()
//         {
//             // arrange
//             RestClient client = new RestClient("https://localhost:5002/api");
//             RestRequest request = new RestRequest("userdetails", Method.GET);

//             // act
//             IRestResponse response = client.Execute(request);
//             // assert
//             Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
//         }
//     }
// }






// ############################
   






// #######################
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


