using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // Get homepage
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Welcome to our home page. Please log in.";
        }
    }
}