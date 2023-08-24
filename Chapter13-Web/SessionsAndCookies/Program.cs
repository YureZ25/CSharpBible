using Microsoft.AspNetCore.Session;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// ������ - ���������� ��������� �� �������, ��������������� � ���������� ���� � ��������
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".ThisSite.Session"; // ���������� �������� ����, �� ��������� �������� ����� ������������� ������
    options.Cookie.Path = SessionDefaults.CookiePath; // ����, ��� �������� ����� ����������� ����, �� �������� - ��� ������ url
    options.Cookie.HttpOnly = true; // �������� �� ���� ��� ����������� ����
    options.Cookie.IsEssential = true; // ����������� �� ��� ������ �����
    options.Cookie.SameSite = SameSiteMode.Strict; // � ��������� � ����� ������ ���������� ���� ����
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // ���������� ����������� �������� �� HTTP ��� ������ HTTPS
    options.IdleTimeout  = TimeSpan.FromMinutes(5); // ����� ����� ������ �� ������� (������� �������)
});

var app = builder.Build();

app.MapDefaultControllerRoute();

app.UseSession(); // ������� middleware ��� ������

app.Run();
