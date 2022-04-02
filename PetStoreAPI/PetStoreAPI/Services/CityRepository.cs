using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class CityRepository : ICityRepository
    {
        private ApplicationDbContext _db;

        public CityRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(City city)
        {
            if (city != null)
            {
                await _db.Cities.AddAsync(city);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int cityId)
        {
            var city = await ReadAsync(cityId);

            _db.Cities.Remove(city);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> ReadAllAsync()
        {
            return await _db.Cities.ToListAsync();
        }

        public async Task<City> ReadAsync(int cityId)
        {
            return await _db.Cities.FirstOrDefaultAsync(a => a.Id == cityId);
        }

        public async Task UpdateAsync(int cityId, City city)
        {
            var toUpdate = await ReadAsync(cityId);

            if (city != null)
            {
                toUpdate.ZipCode = city.ZipCode;
                toUpdate.Location = city.Location;
                toUpdate.State = city.State;
                toUpdate.AreaCode = city.AreaCode;
                toUpdate.Population1990 = city.Population1990;
                toUpdate.Population1980 = city.Population1980;
                toUpdate.Country = city.Country;
                toUpdate.Latitude = city.Latitude;
                toUpdate.Longitude = city.Longitude;


                await _db.SaveChangesAsync();
            }
        }
    }
}
