using System.Diagnostics;
using LabWork5.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabWork5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
