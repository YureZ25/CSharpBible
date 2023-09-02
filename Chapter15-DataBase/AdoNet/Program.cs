using AdoNet.Model.DbConnection;
using AdoNet.Model.DbConnection.Interfaces;
using AdoNet.Model.Providers;
using AdoNet.Model.Providers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

// Внежряем нужную нам зависимость
builder.Services.AddScoped<ICityProvider, CityProvider>();
//builder.Services.AddScoped<ICityProvider, DapperCityProvider>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
