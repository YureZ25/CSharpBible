using Microsoft.AspNetCore.Mvc;
using SessionsAndCookies.ViewModels;

namespace SessionsAndCookies.Controllers
{
    public class PersonalInfoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm] PersonVM person)
        {
            if (ModelState.IsValid)
            {
                // Помещаем значения в хранилище сессии (состояние на сервере)
                HttpContext.Session.SetString(nameof(PersonVM.FirstName), person.FirstName);
                HttpContext.Session.SetInt32(nameof(PersonVM.Age), person.Age);

                // Так можно брать значения не указанные в аргументах эндпоинта
                if (Request.Form.TryGetValue("RememberEmail", out var rememberEmail))
                {
                    // Так можно добавить куки на клиенте - отправив их вместе с респонсом
                    HttpContext.Response.Cookies.Append(
                        nameof(PersonVM.Email),
                        person.Email,
                        new CookieOptions
                        {
                            Expires = DateTimeOffset.UtcNow.AddHours(2), // Время протухания
                            MaxAge = TimeSpan.FromSeconds(30), // Максимальный срок существования
                            Path = "/PersonalInfo", // Путь для которого клиент будет отправлять этот кук
                            Secure = true, // Передавать только по SSL
                            HttpOnly = true, // Не доступно JS на клиенте
                            IsEssential = true, // Важное
                            SameSite = SameSiteMode.Lax, // Стртегия передачи на другие сайты
                        });
                }

                return Redirect("/");
            }

            return View(person);
        }

        [HttpPost]
        public IActionResult Clean()
        {
            // Очистка куков
            HttpContext.Response.Cookies.Delete(nameof(PersonVM.Email));

            // Очистка данных сессии, куки сессии остается до окончания срока жизни
            HttpContext.Session.Clear();

            return View("Index");
        }
    }
}
