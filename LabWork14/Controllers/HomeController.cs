using Microsoft.AspNetCore.Mvc;

namespace LabWork14.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from API!");
        }
    }
}