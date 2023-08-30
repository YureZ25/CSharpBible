using AdoNet.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AdoNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public HomeController(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IActionResult Index()
        {
            return View();
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
    }
}
