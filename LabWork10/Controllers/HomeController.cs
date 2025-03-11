using System.Diagnostics;
using LabWork10.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabWork10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        // ����������� html-��������
        public IActionResult Index()
        {
            return View();
        }

        // ����������� json
        public IActionResult GetJson()
        {
            return Json(new { name = "Timur", age = 20 });
        }


        // ����������� �����
        public IActionResult GetFile()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "files", "TextFile1.txt");
            var fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "text/plain", "TextFile1.txt");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
