using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface ISaleRepository
    {
        Task<Sale> ReadAsync(int saleId);
        Task<IEnumerable<Sale>> ReadAllAsync();
        Task CreateAsync(Sale sale);
        Task UpdateAsync(int saleId, Sale sale);
        Task DeleteAsync(int saleId);
    }
}
