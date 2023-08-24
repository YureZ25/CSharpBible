using Microsoft.AspNetCore.Mvc;

namespace SessionsAndCookies.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
