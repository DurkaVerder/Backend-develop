using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

public class DistributedController : Controller
{
    private readonly IDistributedCache _cache;

    public DistributedController(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<IActionResult> Index()
    {
        var key = "DistributedTime";
        var cached = await _cache.GetStringAsync(key);

        if (cached == null)
        {
            cached = DateTime.Now.ToString("T");
            await _cache.SetStringAsync(key, cached, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20)
            });
        }

        ViewBag.Time = cached;
        return View();
    }
}
