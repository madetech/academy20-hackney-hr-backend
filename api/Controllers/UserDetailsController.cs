// using Microsoft.AspNetCore.Mvc;
// using System.IO;


// namespace API.Controllers
// {
//     public class JsonFileReader
//     {
//         public static string Main()
//         {
//             // return File.ReadAllText("../mock_data.json");
//             return "name";
//         }
//     }

//     [Route("api/[controller]")]
//     [ApiController]

//     public class UserDetailsController : ControllerBase
//     {
//         // Get homepage
//         [HttpGet]
//         public ActionResult<string> Get()
//         {
//             var fileReader = JsonFileReader.Main();
//             return fileReader;

//         }
//     }
// }