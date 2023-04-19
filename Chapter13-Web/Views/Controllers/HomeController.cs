using Microsoft.AspNetCore.Mvc;
using Views.ViewModels;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // В качестве параметра можно указать название представления
            // Фреймворк пытается его найти в "Views/{controllerName}/{actionName}.cshtml",
            // а потом в "Views/Shared/{actionName}.cshtml"
            return View("Main");

            // Или путь, если они храниятся не по стандартной схеме, описанной выше
            // Он пишется относительно предполагаемого места
            //return View("../../ViewModels/Main");
        }

        public IActionResult Person()
        {
            var me = new Person("Yura", "Nikitin", 25);

            // Метод также принимает произвольный объект модели представления
            // Представление исчется по стандартной схеме
            return View(me);
        }

        public IActionResult ConditionalOperators()
        {
            return View();
        }

        public IActionResult Loops()
        {
            var list = new Person[]
            {
                new("Yura", "Nikitin", 25),
                new("Tanya", "Prokopenko", 21),
                new("Mikhail", "Flenov", 42),
                new("Ivan", "Sergeev", 29),
                new("Lena", "Petrova", 19),
            };

            return View(list);
        }

        public IActionResult Etc()
        {
            return View();
        }
    }
}
