﻿using AdoNet.Model.DataModels;
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

            using (var connection = _connectionFactory.CreateConnection()) // По окончанию блока using соединение закроется
            {
                var command = connection.CreateCommand();

                command.CommandText = "SELECT CityId, CityName FROM Cities"; // Пишем чистый SQL

                using (var reader = await command.ExecuteReaderAsync()) // Читаем из БД построчно
                {
                    while (await reader.ReadAsync()) // Переход на следующую строку
                    {
                        cities.Add(new City // Берем данные из текущей строки с помощью Get методов,
                        {
                            CityId = reader.GetInt32(0), // Параметр здесь - номер столбца в выборке
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
                // Как принято в SQL ставим @ перед именем параметра
                command.CommandText = "SELECT CityId, CityName FROM Cities WHERE CityId = @cityId";
                // Добавляем к объекту комманды параметр со значением, чтобы он потом подставился
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@cityId",
                    Value = cityId,
                    SqlDbType = System.Data.SqlDbType.Int, // Не обязательно, но полезно
                });

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows && await reader.ReadAsync()) // Перед чтением первой строки проверяем есть ли они вообще
                    {
                        return new City
                        {
                            CityId = reader.GetInt32(0),
                            CityName = reader.GetString(1),
                        };
                    }
                }
            }

            return null; // Если ничего не нашли - возвращаем пустоту
        }

        public async Task UpdateCity(City city)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var command = connection.CreateCommand();

                command.CommandText = "UPDATE Cities SET CityName = @cityName WHERE CityId = @cityId";

                // Более краткий способ добавления параметров
                command.Parameters.AddWithValue("@cityId", city.CityId);
                command.Parameters.AddWithValue("@cityName", city.CityName);

                await command.ExecuteNonQueryAsync(); // Используем когда запрос не возвращает данные
            }
        }

        public async Task DeleteCity(int cityId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var transaction = connection.BeginTransaction(); // Начинаем транзакцию
                // Все комманды далее могут быть подтверждены или откачены как единое целое

                var getCommand = connection.CreateCommand();
                getCommand.Transaction = transaction; // Связываем комманду с транзакцией
                getCommand.CommandText = "SELECT CityId, CityName FROM Cities WHERE CityId = @cityId";
                getCommand.Parameters.AddWithValue("@cityId", cityId);

                City city;
                using (var getCommandReader = await getCommand.ExecuteReaderAsync())
                {
                    if (!getCommandReader.HasRows)
                    {
                        await transaction.RollbackAsync(); // Откатываем изменения
                        return;
                    }
                    await getCommandReader.ReadAsync();
                    city = new City
                    {
                        CityId = getCommandReader.GetInt32(0),
                        CityName = getCommandReader.GetString(1),
                    };
                }

                var deleteCommand = connection.CreateCommand();
                deleteCommand.Transaction = transaction;
                deleteCommand.CommandText = "DELETE Cities WHERE CityId = @cityId";
                deleteCommand.Parameters.AddWithValue("@cityId", city.CityId);
                await deleteCommand.ExecuteNonQueryAsync();

                await transaction.CommitAsync(); // Подтверждаем транзакцию
            }
        }
    }
}
