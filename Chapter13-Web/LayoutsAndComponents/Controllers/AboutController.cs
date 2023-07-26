using Microsoft.AspNetCore.Mvc;

namespace LayoutsAndComponents.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
