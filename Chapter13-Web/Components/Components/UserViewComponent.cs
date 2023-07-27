using Components.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Components.Components
{
    public class UserViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string userName)
        {
            // Здесь должна быть сформирована модель для отображения
            // Можно передавать данные компоненту снаружи
            // Можно исопльзовать заинжекшеные сервисы
            
            var currentUser = new User
            {
                IsLoggedIn = true,
                Username = userName
            };

            return View("User", currentUser);
        }

        // Может быть (желательно) использовать асинхронный метод
        // Task<IViewComponentResult> InvokeAsync(args)
    }
}
