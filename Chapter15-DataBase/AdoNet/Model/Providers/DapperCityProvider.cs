using AdoNet.Model.DataModels;
using AdoNet.Model.DbConnection.Interfaces;
using AdoNet.Model.Providers.Interfaces;
using Dapper;

namespace AdoNet.Model.Providers
{
    public class DapperCityProvider : ICityProvider // Реализуем тот же интерфейс, но с помощью Dapper
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DapperCityProvider(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            // Dapper использует SqlConnection
            using var connection = _connectionFactory.CreateConnection();

            // Dapper сам промаппит нужные поля
            return await connection.QueryAsync<City>("SELECT * FROM Cities");
        }

        public async Task<City?> GetCity(int cityId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleAsync<City>(
                "SELECT * FROM Cities WHERE CityId = @id", 
                new { id = cityId }); // Параметры передаются в анонимном объекте и подставляются по имени
        }

        public async Task<City> InsertCity(string cityName)
        {
            using var connection = _connectionFactory.CreateConnection();

            var id = await connection.QuerySingleAsync<int>( // Для возврата id пользуемся встроеной в MS SQL функцией SCOPE_IDENTITY()
                "INSERT INTO Cities (CityName) VALUES (@cityName); SELECT CAST(SCOPE_IDENTITY() AS int)",
                new { cityName });

            return new City { CityId = id, CityName = cityName };
        }

        public async Task UpdateCity(City city)
        {
            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                "UPDATE Cities SET CityName = @cityName WHERE CityId = @cityId",
                city); // Можно передать и конкретный объект, главное чтобы у Dapper получилось промапить параметры
        }

        public async Task DeleteCity(int cityId)
        {
            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync("DELETE Cities WHERE CityId = @cityId", new { cityId });
        }
    }
}
