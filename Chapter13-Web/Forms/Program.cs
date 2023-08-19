var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();

app.UseStaticFiles(); // Для получения стилей

app.MapDefaultControllerRoute();

app.Run();
