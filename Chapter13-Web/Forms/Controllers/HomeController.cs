using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
