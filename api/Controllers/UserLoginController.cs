using System;
using API.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UserLoginController : ControllerBase
    {

        // POST request
        [HttpPost]
        public ActionResult<string> Post([FromBody] UserLogin user)
        {
            "Username": "username",
            "Password": "password"
        }
    }
}