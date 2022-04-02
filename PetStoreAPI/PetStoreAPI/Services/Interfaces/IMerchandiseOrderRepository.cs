using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface IMerchandiseOrderRepository
    {
        Task<MerchandiseOrder> ReadAsync(int PONumber);
        Task<IEnumerable<MerchandiseOrder>> ReadAllAsync();
        Task CreateAsync(MerchandiseOrder merchandiseOrder);
        Task UpdateAsync(int PONumber, MerchandiseOrder merchandiseOrder);
        Task DeleteAsync(int PONumber);
    }
}
