using Microsoft.AspNetCore.Mvc;


public class HomeController : Controller
{
    // Для пути /Home/Index
    public IActionResult Index()
    {
        return View();
    }

    // Для пути /Home/Hello
    public IActionResult Hello()
    {
        return View();
    }
}