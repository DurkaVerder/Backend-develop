using System.Diagnostics;
using LabWork7.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabWork7.Controllers
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

            _logger.LogInformation("Info: Запрос получен.");
            _logger.LogDebug("Debug: Детали запроса...");
            _logger.LogWarning("Warning: Потенциальная проблема.");
            _logger.LogError("Error: Произошла ошибка.");
            _logger.LogCritical("Critical: Критическая ошибка!");

            return View();
        }
    }
}
