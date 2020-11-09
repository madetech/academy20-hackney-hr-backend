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
    public class EmployeeIntegrationTests
    : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
    [Fact]
    public async Task GetEmployeeList()
    }
} 