using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [HttpGet]
        public object Get()
        {
            var responseObject = new
            {
                Status = "Up"
            };
            _logger.LogInformation($"Status pinged: {responseObject}");
            return responseObject;
        }
    }
}