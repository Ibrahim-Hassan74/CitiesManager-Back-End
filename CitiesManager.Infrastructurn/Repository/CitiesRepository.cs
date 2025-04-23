using CitiesManager.Core.Models;
using CitiesManager.Core.RepositoryContracts;
using CitiesManager.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesManager.Infrastructure.Repository
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly ApplicationDbContext _context;
        public CitiesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<City> AddCityAsync(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<bool> DeleteCityAsync(Guid id)
        {
            var city = _context.Cities.Find(id);
            if (city != null)
            {
                _context.Cities.Remove(city);
                var res = await _context.SaveChangesAsync();
                return res > 0;
            }
            return false;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            var cities = await _context.Cities.ToListAsync();
            return cities;
        }

        public async Task<City?> GetCityByIdAsync(Guid id)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(x => x.CityID == id);
            return city;
        }

        public Task<City?> GetCityByNameAsync(string name)
        {
            var city = _context.Cities.FirstOrDefaultAsync(x => x.CityName == name);
            return city;
        }

        public async Task<bool> UpdateCityAsync(Guid id, City city)
        {
            var cityFromDataStore = await _context.Cities.FirstOrDefaultAsync(x => x.CityID == id);
            if (cityFromDataStore != null)
            {
                _context.Cities.Update(cityFromDataStore);
                var res = await _context.SaveChangesAsync();
                return res > 0;
            }
            return false;
        }
    }
}
