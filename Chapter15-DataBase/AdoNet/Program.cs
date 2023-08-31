using AdoNet.Model.DbConnection;
using AdoNet.Model.DbConnection.Interfaces;
using AdoNet.Model.Providers;
using AdoNet.Model.Providers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

builder.Services.AddScoped<ICityProvider, CityProvider>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
