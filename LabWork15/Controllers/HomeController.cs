using System.Diagnostics;
using LabWork15.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LabWork15.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index() => View();

        public IActionResult AccessDenied() => View();

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, true, false);
            if (result.Succeeded) return RedirectToAction("Index");
            ModelState.AddModelError("", "Неверные данные"); return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
