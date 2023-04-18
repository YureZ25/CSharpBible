var builder = WebApplication.CreateBuilder(args);

// ������������ ������� ��� ������ ������������ � �������������
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();

// ����� ������ ������������� �� �������� {controller=Home/{action=Index}/{id?}
//app.MapDefaultControllerRoute();

// ����� ������� ��������� ��������, ����� �� ������� �����
// ������ ������������ �� ����� ����������� � ������ ������
app.MapControllerRoute(
    name: "withReturn",
    pattern: "with-return/{controller=Home}/{action=Index}/{returnUrl?}");

app.MapControllerRoute(
    name: "default", 
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
