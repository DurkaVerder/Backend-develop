using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

public class HomeController : Controller
{
    private readonly IMemoryCache _memoryCache;

    public HomeController(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public IActionResult Index()
    {
        var cacheKey = "CurrentTime";
        if (!_memoryCache.TryGetValue(cacheKey, out string currentTime))
        {
            currentTime = DateTime.Now.ToString("T");

            _memoryCache.Set(cacheKey, currentTime, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(10)
            });
        }

        ViewBag.Time = currentTime;
        return View();
    }
}
