using Data;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// �������� ����������� ������� �� �����
builder.Services.AddDataLayer();
builder.Services.AddServiceLayer();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
