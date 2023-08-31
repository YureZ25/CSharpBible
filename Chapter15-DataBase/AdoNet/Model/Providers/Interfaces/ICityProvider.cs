using AdoNet.Model.DataModels;

namespace AdoNet.Model.Providers.Interfaces
{
    public interface ICityProvider
    {
        Task<IEnumerable<City>> GetCities();

        Task<City?> GetCity(int cityId);

        Task UpdateCity(City city);

        Task DeleteCity(int cityId);
    }
}
