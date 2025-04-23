using System.Diagnostics;
using LabWork9.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabWork9.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View("Error");
        }

        public IActionResult StatusCode(int code)
        {
            if (code == 404)
                return View("Error404");

            return View("Error");
        }
    }
}