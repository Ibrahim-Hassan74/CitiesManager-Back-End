using CitiesManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesManager.Core.RepositoryContracts
{
    public interface ICitiesRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City?> GetCityByIdAsync(Guid id);
        Task<City?> GetCityByNameAsync(string name);
        Task<City> AddCityAsync(City city);
        Task<bool> UpdateCityAsync(Guid id, City city);
        Task<bool> DeleteCityAsync(Guid id);
    }
}
