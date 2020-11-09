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

        [Fact]
        public async Task GetOneEmployee()
        {
            // arrange
            
            // act
            var response = await httpClient.GetAsync("api/employee");
            // assert
            var stringResponse = await response.Content.ReadAsStringAsync();
            var terms = JsonSerializer.Deserialize<List<Employee>>(stringResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            Assert.Equal(4, terms.Count);
            Assert.Contains(terms, t => t.id == 1);
            Assert.Contains(terms, t => t.first_name == "Ben");
            Assert.Contains(terms, t => t.last_name == "Dalton");
            Assert.Contains(terms, t => t.job_title == "Academy Software Engineer");
            Assert.Contains(terms, t => t.contact_email == "ben.dalton@madetech.com");

        }
    }
    
} 