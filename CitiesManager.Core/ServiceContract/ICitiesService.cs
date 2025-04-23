using CitiesManager.Core.Models;

namespace CitiesManager.Core.ServiceContract
{
    public interface ICitiesService
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City?> GetCityByIdAsync(Guid id);
        Task<City?> GetCityByNameAsync(string name);
        Task<City> AddCityAsync(City city);
        Task<bool> UpdateCityAsync(Guid id, City city);
        Task<bool> DeleteCityAsync(Guid id);
        Task<IEnumerable<City>?> SearchCitiesAsync(string? searchString);
    }
}
