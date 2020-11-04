using Microsoft.AspNetCore.Mvc;
using System.IO;


namespace API.Controllers
{
    public class JsonFileReader
    {
        public static string Main()
        {
            return File.ReadAllText("/Users/ben_dalton/Desktop/Github/academy2020/academy20-hackney-hr-backend/mock_data.json");
        }
    }

    [Route("api/[controller]")]
    [ApiController]

    public class UserDetailsController : ControllerBase
    {
        // Get homepage
        [HttpGet]
        public ActionResult<string> Get()
        {
            var fileReader = JsonFileReader.Main();
            return fileReader;

        }
    }
}