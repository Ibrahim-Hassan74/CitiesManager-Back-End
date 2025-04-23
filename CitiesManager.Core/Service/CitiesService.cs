using CitiesManager.Core.Models;
using CitiesManager.Core.ServiceContract;
using CitiesManager.Core.RepositoryContracts;

namespace CitiesManager.Core.Service
{
    public class CitiesService : ICitiesService
    {
        private readonly ICitiesRepository _citiesRepository;
        public CitiesService(ICitiesRepository context)
        {
            _citiesRepository = context;
        }

        public async Task<City> AddCityAsync(City city)
        {
            await _citiesRepository.AddCityAsync(city);
            return city;
        }

        public async Task<bool> DeleteCityAsync(Guid id)
        {
            City? city = await _citiesRepository.GetCityByIdAsync(id);
            if (city != null)
            {
                await _citiesRepository.DeleteCityAsync(city.CityID);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return (await _citiesRepository.GetCitiesAsync()).ToList();
        }

        public async Task<City?> GetCityByIdAsync(Guid id)
        {
            City? city = await _citiesRepository.GetCityByIdAsync(id);
            return city;
        }

        public async Task<City?> GetCityByNameAsync(string name)
        {
            City? city = await _citiesRepository.GetCityByNameAsync(name);
            return city;
        }

        public async Task<bool> UpdateCityAsync(Guid id, City city)
        {
            if (id != city.CityID)
            {
                return false;
            }

            City? cityFromDataStore = await _citiesRepository.GetCityByIdAsync(id);
            if (cityFromDataStore != null)
            {
                cityFromDataStore.CityName = city.CityName;
                await _citiesRepository.UpdateCityAsync(id, cityFromDataStore);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<City>?> SearchCitiesAsync(string? searchString)
        {
            var cities = await _citiesRepository.GetCitiesAsync();
            if (string.IsNullOrEmpty(searchString))
            {
                return cities;
            }
            return cities.Where(c => c.CityName.Contains(searchString, StringComparison.OrdinalIgnoreCase));
        }
    }
}
