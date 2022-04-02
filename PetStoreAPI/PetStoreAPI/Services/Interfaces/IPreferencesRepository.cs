using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface IPreferencesRepository
    {
        Task<Preferences> ReadAsync(int keyId);
        Task<IEnumerable<Preferences>> ReadAllAsync();
        Task CreateAsync(Preferences preferences);
        Task UpdateAsync(int keyId, Preferences preferences);
        Task DeleteAsync(int keyId);
    }
}
