using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminPanel()
        {
            return View();
        }

        [Authorize]
        public IActionResult UserPanel()
        {
            return View();
        }
    }
}