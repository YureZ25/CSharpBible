using Microsoft.AspNetCore.Mvc;

namespace Components.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
