using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/home")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Index page");
    }

    [HttpGet("hello")]  
    public IActionResult Hello()
    {
        return Ok("Hello World");
    }
}