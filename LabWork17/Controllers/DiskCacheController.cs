using Microsoft.AspNetCore.Mvc;
using System.IO;

public class DiskCacheController : Controller
{
    private readonly string _cachePath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "diskcache.txt");
    private readonly TimeSpan _cacheLifetime = TimeSpan.FromSeconds(15);

    public IActionResult Index()
    {
        string cachedTime = null;

        if (System.IO.File.Exists(_cachePath))
        {
            var lastWrite = System.IO.File.GetLastWriteTime(_cachePath);

            if (DateTime.Now - lastWrite < _cacheLifetime)
            {
                cachedTime = System.IO.File.ReadAllText(_cachePath);
            }
        }

        if (cachedTime == null)
        {
            cachedTime = DateTime.Now.ToString("T");
            Directory.CreateDirectory(Path.GetDirectoryName(_cachePath));
            System.IO.File.WriteAllText(_cachePath, cachedTime);
        }

        ViewBag.Time = cachedTime;
        return View();
    }
}
