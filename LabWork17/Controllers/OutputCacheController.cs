using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

public class OutputCacheController : Controller
{
    [OutputCache(Duration = 10)]
    public IActionResult Index()
    {
        ViewBag.Time = DateTime.Now.ToString("T");
        return View();
    }
}
