using Microsoft.AspNetCore.Mvc;

namespace Sections.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
