using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    // Здесь путь к эндпоинту определяется с помошью аттрибутов
    [Route("my/test")]
    public class TestController : Controller
    {
        // Здесь переопределяем название action
        [Route("show")] // По умолчанию - GET
        public IActionResult Index()
        {
            return Content("Index Test method");
        }

        // Можно пользоваться аттрибутами метода и пути отдельно, но это не так удобно
        [HttpPost]
        [Route("details/{id}")] // Если параметр без ? то он обязательный без него будет 404
        public IActionResult Details(int id)
        {
            return Content($"Details for id = {id}");
        }
    }
}
