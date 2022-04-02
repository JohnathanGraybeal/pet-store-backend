using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface ICityRepository
    {
        Task<City> ReadAsync(int cityId);
        Task<IEnumerable<City>> ReadAllAsync();
        Task CreateAsync(City animal);
        Task UpdateAsync(int cityId, City city);
        Task DeleteAsync(int cityId);
    }
}
