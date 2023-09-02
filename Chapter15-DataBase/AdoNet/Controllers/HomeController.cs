using AdoNet.Model.DataModels;
using AdoNet.Model.DbConnection.Interfaces;
using AdoNet.Model.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AdoNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly ICityProvider _cityProvider;

        public HomeController(IDbConnectionFactory connectionFactory, ICityProvider cityProvider)
        {
            _connectionFactory = connectionFactory;
            _cityProvider = cityProvider;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await _cityProvider.GetCities();

            return View(cities); // Передача view доменной модели - не лучшая идея, лучше использовать ViewModel (DTO)
        }

        // Технически мы можем открыть соединение прямо из контроллера, но так лучше не делать
        public IActionResult OpenConnectionHereAndNow()
        {
            // В нормальном варианте строка подключения берется из конфигурации
            using var connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=todo_db;User Id=sa;Password=,fpf2597;TrustServerCertificate=True;");

            connection.Open(); // Открытие соединения (физически провайдер может уже иметь
                               // свободное открытое соединение к БД, что позволит избежать накладных расходов)

            return Ok(connection.State.ToString());
            // Т.к. SqlConnection реализует IDisposable, при выходе из метода соединение закроется
        }

        public IActionResult GetConnectionFromFactory()
        {
            // Так у нас не будет раскрыто деталей конфигурации
            using var connection = _connectionFactory.CreateConnection();

            return Ok(connection.State.ToString());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] string cityName)
        {
            await _cityProvider.InsertCity(cityName);

            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            return View(await _cityProvider.GetCity(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] City city)
        {
            await _cityProvider.UpdateCity(city);

            return Redirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _cityProvider.DeleteCity(id);

            return Redirect("/");
        }
    }
}
