using Data;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Внедряем зависимости каждого из слоев
builder.Services.AddDataLayer();
builder.Services.AddServiceLayer();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
