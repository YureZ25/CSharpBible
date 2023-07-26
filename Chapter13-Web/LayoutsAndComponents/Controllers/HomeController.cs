using Microsoft.AspNetCore.Mvc;

namespace LayoutsAndComponents.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var langs = new[] { "C#", "JS", "TS", "Python", "1C", "Украинский" };

            return View(langs);
        }
    }
}
