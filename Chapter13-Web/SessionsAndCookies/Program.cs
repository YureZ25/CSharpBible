using Microsoft.AspNetCore.Session;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Сессия - сохранясое состояние на сервере, ассоциированное с уникальным куки в браузере
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".ThisSite.Session"; // Определяет название кука, со значением которого будет ассоциирована сессия
    options.Cookie.Path = SessionDefaults.CookiePath; // Путь, для которого будет отправлятся куки, по умолчнию - для любого url
    options.Cookie.HttpOnly = true; // Доступно ли куки для клиентского кода
    options.Cookie.IsEssential = true; // Обязательно ли для работы сайта
    options.Cookie.SameSite = SameSiteMode.Strict; // С запросами к каким сайтам отправлять этот куки
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Определяет возможность отправки по HTTP или только HTTPS
    options.IdleTimeout  = TimeSpan.FromMinutes(5); // Время жизни сессии на сервере (таймаут простоя)
});

var app = builder.Build();

app.MapDefaultControllerRoute();

app.UseSession(); // Включем middleware для сессии

app.Run();
