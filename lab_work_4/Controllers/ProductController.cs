using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    [HttpGet("{index:int}")]
    public IActionResult Index(int index)
    {   
        return Ok($"Index page of product {index}");
    }

    [HttpGet("hello")]
    public IActionResult Hello()
    {
        return Ok("Hello World from ProductController");
    }
}