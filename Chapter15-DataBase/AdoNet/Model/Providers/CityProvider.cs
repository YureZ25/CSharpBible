using AdoNet.Model.DataModels;
using AdoNet.Model.DbConnection.Interfaces;
using AdoNet.Model.Providers.Interfaces;

namespace AdoNet.Model.Providers
{
    public class CityProvider : ICityProvider
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public CityProvider(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            var cities = new List<City>();

            using (var connection = _connectionFactory.CreateConnection())
            {
                var command = connection.CreateCommand();

                command.CommandText = "SELECT CityId, CityName FROM Cities";

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        cities.Add(new City
                        {
                            CityId = reader.GetInt32(0),
                            CityName = reader.GetString(1),
                        });
                    }
                }
            }

            return cities;
        }
    }
}
