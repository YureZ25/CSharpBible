
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Теперь подробное отображение ощибок включено в dev env по умолчанию
// Environment можно поменять в launchSettings.json
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

// Так можно настроить доступ к статическим файлам из папки wwwroot
app.UseStaticFiles("/files");

// Базовая конфигурация эндпоинта
app.MapGet("/", () => "Welcome to root endpont!");

// То же действие, только через RequestDelegate(HttpContext context)
app.MapGet("/about", async (context) => await context.Response.WriteAsync("This is something very interesting about..."));

// Использование данных из конфигурации
app.MapGet("/buy", () => app.Configuration["ProductMessage"]);

// Предыдущий подход, сейчас проще испольщовать Map() сразу от app
//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/", async context =>
//    {
//        await context.Response.WriteAsync("Hello World!");
//    });
//});

app.Run();
