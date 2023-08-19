using Forms.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Title = "GET Login";
            return View(); // Модель на представлении будет null
        }

        [HttpPost]
        public IActionResult Login([FromForm] LoginVM loginVM)
        {
            ViewBag.Title = "POST Login";
            return View(loginVM);
        }
    }
}
