using Microsoft.AspNetCore.Mvc;
using PartialViews.ViewModels;

namespace PartialViews.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
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

        public IActionResult Details()
        {
            return View(new Person("Yura", "Nikitin", 25));
        }
    }
}
