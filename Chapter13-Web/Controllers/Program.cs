var builder = WebApplication.CreateBuilder(args);

// –егистрируем сервисы дл€ работы контроллеров и представлений
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();

// ћапит шаблон маршрутизации по умочанию {controller=Home/{action=Index}/{id?}
//app.MapDefaultControllerRoute();

// ћожно смапить несколько шаблонов, здесь их пор€док важен
// ƒолжны распологатс€ от более конкретного к самому общему
app.MapControllerRoute(
    name: "withReturn",
    pattern: "with-return/{controller=Home}/{action=Index}/{returnUrl?}");

app.MapControllerRoute(
    name: "default", 
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
