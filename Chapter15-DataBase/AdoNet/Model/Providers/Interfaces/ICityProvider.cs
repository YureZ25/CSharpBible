using AdoNet.Model.DataModels;

namespace AdoNet.Model.Providers.Interfaces
{
    public interface ICityProvider
    {
        Task<IEnumerable<City>> GetCities();
    }
}
