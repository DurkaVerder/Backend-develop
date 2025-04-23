using Microsoft.AspNetCore.Mvc;

namespace LabWork9.Controllers
{
    public class TestController : Controller
    {
        public IActionResult ThrowException()
        {
            throw new Exception("Это общая ошибка!");
        }

        public IActionResult DbError()
        {
            throw new InvalidOperationException("Ошибка подключения к базе данных!");
        }
    }
}
