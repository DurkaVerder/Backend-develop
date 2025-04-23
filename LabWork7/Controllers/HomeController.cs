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

            _logger.LogInformation("Info: ������ �������.");
            _logger.LogDebug("Debug: ������ �������...");
            _logger.LogWarning("Warning: ������������� ��������.");
            _logger.LogError("Error: ��������� ������.");
            _logger.LogCritical("Critical: ����������� ������!");

            return View();
        }
    }
}
