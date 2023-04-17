
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ������ ��������� ����������� ������ �������� � dev env �� ���������
// Environment ����� �������� � launchSettings.json
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

// ��� ����� ��������� ������ � ����������� ������ �� ����� wwwroot
app.UseStaticFiles("/files");

// ������� ������������ ���������
app.MapGet("/", () => "Welcome to root endpont!");

// �� �� ��������, ������ ����� RequestDelegate(HttpContext context)
app.MapGet("/about", async (context) => await context.Response.WriteAsync("This is something very interesting about..."));

// ������������� ������ �� ������������
app.MapGet("/buy", () => app.Configuration["ProductMessage"]);

// ���������� ������, ������ ����� ������������ Map() ����� �� app
//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/", async context =>
//    {
//        await context.Response.WriteAsync("Hello World!");
//    });
//});

app.Run();
