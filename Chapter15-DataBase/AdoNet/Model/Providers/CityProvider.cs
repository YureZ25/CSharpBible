using AdoNet.Model.DataModels;
using AdoNet.Model.DbConnection.Interfaces;
using AdoNet.Model.Providers.Interfaces;
using Microsoft.Data.SqlClient;

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

        public async Task<City?> GetCity(int cityId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var command = connection.CreateCommand();

                command.CommandText = "SELECT CityId, CityName FROM Cities WHERE CityId = @cityId";

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@cityId",
                    Value = cityId,
                    SqlDbType = System.Data.SqlDbType.Int,
                });

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows && await reader.ReadAsync())
                    {
                        return new City
                        {
                            CityId = reader.GetInt32(0),
                            CityName = reader.GetString(1),
                        };
                    }
                }
            }

            return null;
        }

        public async Task UpdateCity(City city)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var command = connection.CreateCommand();

                command.CommandText = "UPDATE Cities SET CityName = @cityName WHERE CityId = @cityId";

                command.Parameters.AddWithValue("@cityId", city.CityId);
                command.Parameters.AddWithValue("@cityName", city.CityName);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteCity(int cityId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var command = connection.CreateCommand();

                command.CommandText = "DELETE Cities WHERE CityId = @cityId";

                command.Parameters.AddWithValue("@cityId", cityId);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
