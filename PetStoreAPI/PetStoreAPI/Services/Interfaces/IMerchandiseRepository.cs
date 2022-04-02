using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface IMerchandiseRepository
    {
        Task<Merchandise> ReadAsync(int itemId);
        Task<IEnumerable<Merchandise>> ReadAllAsync();
        Task CreateAsync(Merchandise merchandise);
        Task UpdateAsync(int itemId, Merchandise merchandise);
        Task DeleteAsync(int itemId);
    }
}
