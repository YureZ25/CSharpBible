using Microsoft.AspNetCore.Mvc;
using SessionsAndCookies.ViewModels;

namespace SessionsAndCookies.Components
{
    public class AdViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var age = HttpContext.Session.GetInt32("Age"); // Берем значение из сессии (если его нет - вернется null)

            // Передаем модель представлению
            return View(new AdVM
            {
                IsAdult = age > 18,
            });
        }
    }
}
