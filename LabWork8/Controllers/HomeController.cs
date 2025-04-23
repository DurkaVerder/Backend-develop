using System.Diagnostics;
using LabWork8.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabWork8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(User model)
        {
         
            HttpContext.Session.SetString("UserName", model.UserName ?? "");
            

            return RedirectToAction("Result");
        }

        public IActionResult Result()
        {
            var model = new User
            {
                UserName = HttpContext.Session.GetString("UserName") ?? "No session value",
            };

            return View(model);
        }
    }
}

